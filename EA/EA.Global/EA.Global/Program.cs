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


                var reserved = await client.RReservedInstances("69309391", 
                    DateTime.UtcNow.AddMonths(-1).ToString("yyyy-MM-dd"),
                    DateTime.UtcNow.ToString("yyyy-MM-dd"));

                Console.WriteLine(reserved);




            }).Wait();
            Console.WriteLine("Hello World!");
        }
    }
}
