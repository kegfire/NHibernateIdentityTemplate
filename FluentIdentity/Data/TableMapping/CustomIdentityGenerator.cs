using NHibernate.Engine;
using NHibernate.Id;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FluentIdentity.Data.TableMapping
{
	/// <summary>
	/// Генератор иденитификаторов .
	/// </summary>
	public class CustomIdentityGenerator : IIdentifierGenerator
	{
		public object Generate(ISessionImplementor session, object obj)
		{
			return Guid.NewGuid().ToString();
		}

		/// <summary>
		/// Метод генератор иденитификатора.
		/// </summary>
		/// <param name="session">
		/// Актуальная сессия ОРМ.
		/// </param>
		/// <param name="obj">
		/// Объект для которого создается иденитификатор.
		/// </param>
		/// <returns>
		/// Новый идентификатор.
		/// </returns>
		public Task<object> GenerateAsync(NHibernate.Engine.ISessionImplementor session, object obj, CancellationToken cancellationToken)
		{
			return Task.FromResult<object>(Guid.NewGuid().ToString());
		}
	}
}
