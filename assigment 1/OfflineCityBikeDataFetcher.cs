using System;
using System.Threading.Tasks;
using System.Linq;
namespace assigment_1
{
    public class OfflineCityBikeDataFetch : ICityBikeDataFetcher
    {
        public void Sorting()
        {
            Console.WriteLine("Readin the file");
        }
        public async Task<int> GetBikeCountInStation(string stationName)
        {
            string[] file = System.IO.File.ReadAllLines(@"C:\Users\roope\Documents\GitHub\taustajarjestelmat\assigment 1\bikedata.txt");
            string[] completeListofNames = new string[file.Length];
            string[] completeListofAmounts = new string[file.Length];
            string insert;
            string insertOfInsert;
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
                var task = new Task(() => Sorting());
                task.Start();
                await task;
                for (int i = 0; i < file.Length; i++)
                {
                    string rivi = file[i];
                    insert = new string(rivi.Where(char.IsLetter).ToArray());
                    completeListofNames[i] = insert;
                    insertOfInsert = new string(rivi.Where(char.IsDigit).ToArray());
                    completeListofAmounts[i] = insertOfInsert;
                }
                OfflineStation station = new OfflineStation(completeListofNames, completeListofAmounts);
                for (int i = 0; i < station.name.Length; i++)
                {
                    if (station.name[i] == stationName)
                    {
                        Console.WriteLine(station.bikesAvailable[i] + "\n" + station.name[i]);
                        return 1;
                    }
                }
                NotFoundException exception = new NotFoundException("Station not found");
                throw exception;
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Exception Caught!");
                Console.WriteLine("Message :", ex.Message);
            }
            catch (NotFoundException ex)
            {
                Console.WriteLine("Exception Caught!");
                Console.WriteLine("Message :", ex.Message);
            }
            return 1;
        }
    }
    public class OfflineStation
    {
        public OfflineStation(string[] lines, string[] bikes)
        {
            name = lines;
            bikesAvailable = bikes;
        }
        public string[] name { get; set; }
        public string[] bikesAvailable { get; set; }
    }
}