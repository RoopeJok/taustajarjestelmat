using System;
using System.IO;
using System.Threading.Tasks;
namespace assigment_1
{
    public class OfflineCityBikeDataFetcher:ICityBikeDataFetcher
    {
        public Task<int> GetBikeCountInStation(string stationName)
        {
            try
            {
                string responseBody;
               using( var sr = new StreamReader("bikedata.txt"))
                {
                    responseBody = sr.ReadToEnd();                   
                }
                int result = Int32.Parse(responseBody);
                return result; 
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read: "+e.Message);
                return 0;
            }
        }
    }
}