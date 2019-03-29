

namespace Azure.JobTrial.Models
{
    public class Config
    {
        public string InternalSasBlobContainer { get; set; }

        public string AzureWebJobsStorage { get; set; }

        public string AzureWebJobsDashboard { get; set; }
    }
}
