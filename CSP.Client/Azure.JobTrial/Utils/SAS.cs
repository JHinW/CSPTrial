// <copyright file="SAS.cs" company="jhinw">
// Copyright (c) jhinw. All rights reserved.
// </copyright>

namespace Azure.JobTrial.Utils
{
    using System;

    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;

    public static class SAS
    {
        public static string GenerateSAS(string containerName, string acs)
        {
            var account1 = CloudStorageAccount.Parse(acs);
            var client = account1.CreateCloudBlobClient();
            var container = client.GetContainerReference(containerName);
            container.CreateIfNotExistsAsync().Wait(); // this will throw if acs is bad

            var now = DateTime.UtcNow;
            var sig = container.GetSharedAccessSignature(new SharedAccessBlobPolicy
            {
                Permissions = SharedAccessBlobPermissions.Read | SharedAccessBlobPermissions.Write | SharedAccessBlobPermissions.List,
                SharedAccessStartTime = now.AddDays(-10),
                SharedAccessExpiryTime = now.AddDays(10)
            });
            var fakeSasUri = container.Uri + sig;

            return fakeSasUri;
        }
    }
}
