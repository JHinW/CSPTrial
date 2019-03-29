namespace Azure.JobTrial
{
    using Azure.JobTrial.Filters;
    using Azure.JobTrial.Models;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Extensions.Logging;

    [ErrorHandler]
    public class Functions
    {
        [WorkItemValidator]
        public void ProcessWorkItem([QueueTrigger("jiwagtest")] WorkItem workItem, ILogger logger)
        {
            // _sampleServiceA.DoIt();
            logger.LogInformation($"Processed work item {workItem.ID}");
        }
    }
}
