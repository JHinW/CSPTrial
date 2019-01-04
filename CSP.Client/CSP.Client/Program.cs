using System;
using System.Threading.Tasks;

namespace CSP.Client
{
    /// <summary>
    /// https://partner.partnercenter.microsoftonline.cn/commerce/preferredoffers/list
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var client = new CSP.Client.Auth.Client();
            Task.Run( async () =>
            {
                var users = await client.Test();
                Console.WriteLine(users);

                //var referrals = await client.TestReferrals();
                //Console.WriteLine(referrals);

                //var indirectresellers = await client.TestIndirectresellers();
                //Console.WriteLine(indirectresellers);




                //var usage = await client.TestPartnerUsage();
                //Console.WriteLine(usage);


                var json = await client.TestDeployment();
                Console.WriteLine(json);

                var usage1 = await client.TestUsage();
                Console.WriteLine(usage1);


                var search = await client.GetAllSearchAnalytics();
                Console.WriteLine(search);
                //var dep = await client.TestCommercialDeployment();
                //Console.WriteLine(dep);


                //var usage = await client.TestCommercialUsage();
                //Console.WriteLine(usage);
            }).Wait();
            Console.WriteLine("Hello World!");
        }
    }
}
