using FluentIdentity.Data.TableMapping;
using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FluentIdentity.Data
{
	public class HibernateContext
	{
		/// <summary>
		/// Признак первого запуска.
		/// </summary>
		private static bool isFirstRun = true;

		/// <summary>
		/// Gets or sets the session factory.
		/// </summary>
		private static ISessionFactory sessionFactory;


		/// <summary>
		/// Конструктор контекста.
		/// </summary>
		/// <param name="cfg">
		/// Для теста. Тело Hibernate.cfg.xml.
		/// </param>
		/// <param name="dataBaseFilePath">
		/// Для теста. Путь к файлу БД.
		/// </param>
		public HibernateContext()
		{
			if (sessionFactory == null)
			{
				sessionFactory = CreateSessionFactory();
				if (sessionFactory != null)
				{
					OpenSession = sessionFactory.OpenSession();
				}
			}
			else
			{
				OpenSession = sessionFactory.OpenSession();
			}
		}

		#region Public Properties

		/// <summary>
		/// Текущая сессия.
		/// </summary>
		public ISession OpenSession { get; set; }
		#endregion

		/// <summary>
		/// Убиваем сессию.
		/// </summary>
		public void Dispose()
		{
			OpenSession?.Dispose();
		}

		/// <summary>
		/// Создание сессии, если признак первого запуска = true тогда производим контроль и приведение к формату схему БД.
		/// </summary>
		/// <returns>
		/// Возвращает фабрику сессий.<see cref="ISessionFactory"/>.
		/// </returns>
		private static ISessionFactory CreateSessionFactory()
		{
			Configuration config;
			FluentConfiguration f;
			try
			{
				config = new Configuration().Configure(Path.Combine(Directory.GetCurrentDirectory(), "hibernate.cfg.xml"));
				f = Fluently.Configure(config);
			}
			catch (Exception e)
			{
				Log.Logger.Error($"Ошибка загрузки конфигурации из файла hibernate.cfg.xml. {e.InnerException}.");
				return null;
			}

			f.Mappings(m => m.FluentMappings.Add<IdentityRoleMap>());
			f.Mappings(m => m.FluentMappings.Add<IdentityRoleClaimsMap>());
			f.Mappings(m => m.FluentMappings.Add<IdentityUserLoginsMap>());
			f.Mappings(m => m.FluentMappings.Add<IdentityUserRolesMap>());
			f.Mappings(m => m.FluentMappings.Add<IdentityUsersMap>());
			f.Mappings(m => m.FluentMappings.Add<IdentityUserTokensMap>());
			f.Mappings(m => m.FluentMappings.Add<IdentityUserClaimsMap>());

			f.Diagnostics(x => x.Enable(true));
			if (isFirstRun)
			{
				var schemaUpdate = new SchemaUpdate(config);
				f.ExposeConfiguration(
					obj =>
					{
						try
						{
							schemaUpdate.Execute(false, true);
							foreach (var e in schemaUpdate.Exceptions)
							{
								Log.Logger.Error($"{e.Message}");
								
							}
						}
						catch (Exception ex)
						{
							Log.Logger.Error($"{ex.StackTrace}");
						}
					});
				isFirstRun = false;
			}
			ISessionFactory session = null;
			var cts = new CancellationTokenSource();
			var newTask = Task.Factory.StartNew(state =>
			{
				session = f.BuildSessionFactory();
			}, cts.Token, cts.Token);
			if (!newTask.Wait(20000, cts.Token))
			{
				cts.Cancel();
				// ReSharper disable once AssignNullToNotNullAttribute
				Log.Logger.Error($"Ошибка подключения к БД. Проверьте настройки подключения в файле hibernate.cfg.xml");
			}
			return session;
		}
	}
}
