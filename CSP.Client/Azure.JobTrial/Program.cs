using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.JobTrial
{
    class Program
    {
        static string StorageConn = "DefaultEndpointsProtocol=https;AccountName=eabus1storagetest;AccountKey=8vlUECbyA6AWMFuJQK5RWyNq6N5Po3S43apXn93/TAML8Mbn2o4y3S/7ZwIY+imLUydSQrEF/WtSnN8r4YX6nQ==;EndpointSuffix=core.chinacloudapi.cn";

        public static void Main(string[] args)

        {
            var builder = new HostBuilder();
            builder.ConfigureWebJobs(b => {

                b.AddAzureStorage(option => {

                }).AddAzureStorageCoreServices();
            }).ConfigureAppConfiguration(config =>
            {
                config.AddInMemoryCollection(new Dictionary<string, string>()
                    {
                            { "AzureWebJobs:InternalSasBlobContainer", "" },
                            { "AzureWebJobsStorage", StorageConn },
                            { "AzureWebJobsDashboard", StorageConn }
                    });
            })
            ;

            // builder.CallAsync(null);
            var host = builder.Build();

           // var jobhost = host.Services.GetService(typeof(IJobHost)) as JobHost;

            host.Run();

            // host.WaitForShutdown();

            // Thread.Sleep(Timeout.Infinite);



        }
    }
}
