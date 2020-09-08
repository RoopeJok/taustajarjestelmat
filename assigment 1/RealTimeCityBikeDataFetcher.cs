using System.Net.Http;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json;

namespace assigment_1
{
    public class RealTimeCityBikeDataFetcher : ICityBikeDataFetcher
    {
        HttpClient client = new HttpClient();
        int bikeCount;

        public async Task<int> GetBikeCountInStation(string stationName)
        {
            try
            {
                foreach (char letter in stationName)
                {
                    if (char.IsDigit(letter))
                    {
                        System.ArgumentException argumentException = new System.ArgumentException("Station name can not contain numbers");
                        throw argumentException;
                    }
                }
                string responseBody = await client.GetStringAsync("http://api.digitransit.fi/routing/v1/routers/hsl/bike_rental");
                BikeRentalStationList bike = JsonConvert.DeserializeObject<BikeRentalStationList>(responseBody);
                for (int i = 0; i < bike.stations.Length; i++)
                {
                    if (bike.stations[i].name == stationName)
                    {
                        bikeCount = bike.stations[i].bikesAvailable;
                        Console.WriteLine(bikeCount + "\n" + stationName);
                        return bikeCount;
                    }
                }
                NotFoundException exception = new NotFoundException("Station not found");
                throw exception;

            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :", ex.Message);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :", ex.Message);

            }
            catch (NotFoundException ex)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :", ex.Message);
            }
            return 1;


        }
    }
}