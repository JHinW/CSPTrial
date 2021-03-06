﻿namespace Azure.JobTrial
{
    using Azure.JobTrial.Filters;
    using Azure.JobTrial.Models;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading.Tasks;

    [ErrorHandler]
    public class Functions
    {
        [WorkItemValidator]
        public async Task ProcessWorkItem([QueueTrigger("jiwagtest")] WorkItem workItem, ILogger logger)
        {
            // _sampleServiceA.DoIt();
            logger.LogInformation($"Processing work item {workItem.ID}");
            await Task.Delay(new TimeSpan(0, 20, 0));

            logger.LogInformation($"Processed work item {workItem.ID}");
        }

        public async Task StartupJob([TimerTrigger("0 30 6 * * *", RunOnStartup = true)] TimerInfo timerInfo, ILogger logger)
        {

            logger.LogInformation("Timer job fired!");
            await Task.Delay(0);
            logger.LogInformation("Timer job completed!");
        }
    }
}
