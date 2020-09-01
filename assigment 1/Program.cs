using System;
using System.Threading.Tasks;

namespace assigment_1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            if(args.Length ==7)
            {
                OfflineCityBikeDataFetcher.GetBikeCountInStation("Luhtimäki");
            }
            if(args.Length ==8)
            {
                RealTimeCityBikeDataFetcher.GetBikeCountInStation("Luhtimäki");
            }
            Console.WriteLine(args[0]);
            //return Task<int>  GetBikeCountInStation("Luhtimäki");
        }
    }
}
