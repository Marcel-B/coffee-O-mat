using com.b_velop.coffee_O_mat.Persistence.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace com.b_velop.coffee_O_mat.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            var builder = CreateHostBuilder(args).Build();

            using var scope = builder.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<CoffeeContext>();
            context.Database.Migrate();
            context.SaveChanges();
            scope.Dispose();
            builder.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); }).ConfigureLogging(
                    logging =>
                    {
                        logging.ClearProviders();
                        logging.AddConsole();
                        logging.SetMinimumLevel(LogLevel.Trace);
                    })
                .UseNLog();
    }
}