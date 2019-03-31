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
            var builder = new HostBuilder()
                .UseEnvironment("Development")
                .ConfigureWebJobs(b =>
                {
                    b.AddAzureStorageCoreServices()
                    .AddAzureStorage();
                })
                //.ConfigureAppConfiguration(b =>
                //{
                //    // Adding command line as a configuration source
                //   // b.AddCommandLine(args);
                //})
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
