using System;
using System.Threading.Tasks;

namespace EA.Global
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new EAClient();
            Task.Run(async () =>
            {
                //var users = await client.CsvNonPolling("69309391", DateTime.UtcNow.ToString("yyyyMM"));
                //Console.WriteLine(users);


                //var reserved = await client.RReservedInstances("69309391", 
                //    DateTime.UtcNow.AddMonths(-1).ToString("yyyy-MM-dd"),
                //    DateTime.UtcNow.ToString("yyyy-MM-dd"));

                //Console.WriteLine(reserved);

                //var reservedcharges = await client.RReservedInstancesCharges("69309391",
                //    DateTime.UtcNow.AddMonths(-5).ToString("yyyy-MM-dd"),
                //    DateTime.UtcNow.ToString("yyyy-MM-dd"));

                //Console.WriteLine(reservedcharges);

                //var reservedRecommendations = await client.RReservedInstancesRecommendations("69309391", 100);

                //Console.WriteLine(reservedRecommendations);


                var balance = await client.BalanceSummary("69309391");

                Console.WriteLine(balance);



                //var price = await client.EAPrice("69309391");

                //Console.WriteLine(price);


                //var pricePeriod = await client.EAPriceBillingPeriod("69309391", DateTime.UtcNow.ToString("yyyyMM"));

                //Console.WriteLine(pricePeriod);





            }).Wait();
            Console.WriteLine("Hello World!");
        }
    }
}
