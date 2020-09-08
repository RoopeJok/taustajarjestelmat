using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace assigment_1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            if (args[0] == "realtime")
            {
                RealTimeCityBikeDataFetcher realTimeCityBike = new RealTimeCityBikeDataFetcher();
                Task<int> amountofbikes = realTimeCityBike.GetBikeCountInStation(args[1]);
                int result = await amountofbikes;
                Console.WriteLine(result);
            }
            else if (args[0] == "offline")
            {
                OfflineCityBikeDataFetch offlineCityBike = new OfflineCityBikeDataFetch();
                Task<int> amountofbikes = offlineCityBike.GetBikeCountInStation(args[1]);
                int result = await amountofbikes;
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Write either realtime or offline");
            }
        }
    }

}
