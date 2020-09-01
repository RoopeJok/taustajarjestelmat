using System.Net.Http;
using System.Threading.Tasks;
using System;
namespace assigment_1
{
    public class RealTimeCityBikeDataFetcher :ICityBikeDataFetcher
    {
        HttpClient client = new HttpClient();
        
        async Task<int>  GetBikeCountInStation(string stationName)
        {
            try	
            {
            if(stationName.Contains ='0'+'1'+'2'+'3'+'4'+'5'+'6'+'7'+'8'+'9')
            {
                throw new ArgumentException("Invalid argument: ",stationName);
            }
            string responseBody = await client.GetStringAsync("http://api.digitransit.fi/routing/v1/routers/hsl/bike_rental");
            int result = Int32.Parse(responseBody);
            return result;
            }
            catch(ArgumentNullException a)
            {
                Console.WriteLine("\nException Caught!");	
                Console.WriteLine("Message :{0} ",a.Message); 
                return 0;
            }
            catch(HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");	
                Console.WriteLine("Message :{0} ",e.Message);
                return 0;
            }
           
            
        }
    }
}