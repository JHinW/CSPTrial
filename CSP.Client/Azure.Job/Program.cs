using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Azure.Job
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            IConfiguration configuration = null;

            var builder = new HostBuilder()
                .UseEnvironment("Development")
                .ConfigureWebJobs(b =>
                {
                    b.AddAzureStorageCoreServices()
                    .AddAzureStorage()
                    .AddTimers();
                })
                .ConfigureAppConfiguration((ctx, configBuilder) =>
                {
                    var env = ctx.HostingEnvironment;

                    configBuilder
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

                    configuration = configBuilder.Build();
                })
                .ConfigureLogging((context, b) =>
                {
                    b.SetMinimumLevel(LogLevel.Debug);
                    b.AddConsole();

                    // If this key exists in any config, use it to enable App Insights

                    //string appInsightsKey = context.Configuration["APPINSIGHTS_INSTRUMENTATIONKEY"];
                    //if (!string.IsNullOrEmpty(appInsightsKey))
                    //{
                    //    b.AddApplicationInsights(o => o.InstrumentationKey = appInsightsKey);
                    //}
                })
                .ConfigureServices(services =>
                {
                    // add some sample services to demonstrate job class DI

                    //services.AddSingleton<ISampleServiceA, SampleServiceA>();
                    //services.AddSingleton<ISampleServiceB, SampleServiceB>();
                })
                .UseConsoleLifetime();

            var host = builder.Build();
            using (host)
            {
                await host.RunAsync();
            }
        }
    }
}
