// <copyright file="Program.cs" company="JHINW">
// Copyright (c) JHINW. All rights reserved.
// </copyright>

namespace Azure.JobTrial
{
    using System.Collections.Generic;
    using System.IO;

    using Azure.JobTrial.Models;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;

    internal class Program
    {
        public static void Main(string[] args)
        {
           var localConfig = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var setting = new Config();

            localConfig.Bind("WebJob", setting);

            var builder = new HostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureWebJobs(b =>
            {
                b.AddAzureStorage(option =>
                {
                }).AddAzureStorageCoreServices();
            })
            .ConfigureAppConfiguration(config =>
            {
                config.AddInMemoryCollection(new Dictionary<string, string>()
                    {
                            { "AzureWebJobs:InternalSasBlobContainer", setting.InternalSasBlobContainer },
                            { "AzureWebJobsStorage", setting.AzureWebJobsStorage },
                            { "AzureWebJobsDashboard", setting.AzureWebJobsDashboard }
                    });
            })
            .ConfigureLogging((ctx, b) =>
            {
                Microsoft.Extensions.Logging.ConsoleLoggerExtensions.AddConsole(b);
            });

            var host = builder.Build();

            host.Run();
        }
    }
}
