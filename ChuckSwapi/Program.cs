using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChuckSwapi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Verbose()
                        .WriteTo.File("C:\\ChuckSwapi-Log\\Log.txt", rollingInterval: RollingInterval.Day, retainedFileCountLimit: null,
                        outputTemplate: "{Timestamp:yyy-MM-dd HH:mm:ss.ff zzz} [{Level:u3} {Message:lj}{NewLine}{Exception}")
                        .CreateLogger();

            Log.Logger.Information("Excuted at {ExecutionTime}", Environment.TickCount);
            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception)
            {

                Log.CloseAndFlush();
            }
            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
