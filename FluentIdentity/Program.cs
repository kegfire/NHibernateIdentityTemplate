using System;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace FluentIdentity
{
	public class Program
	{
		public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
				  .SetBasePath(Directory.GetCurrentDirectory())
				  .AddJsonFile($"appsettings.json", optional: true, reloadOnChange: true)
				  .AddEnvironmentVariables()
				  .Build();

		public static void Main(string[] args)
		{
			try
			{
				Log.Logger = new LoggerConfiguration()
					.ReadFrom.Configuration(Configuration)
					.CreateLogger();
				Log.Information("Starting web host");
				CreateWebHostBuilder(args).Build().Run();
			}
			catch (Exception ex)
			{
				Log.Fatal(ex, "Host terminated unexpectedly");
				return;
			}
			finally
			{
				Log.CloseAndFlush();
			}

		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args).UseSerilog().UseStartup<Startup>();
	}
}
