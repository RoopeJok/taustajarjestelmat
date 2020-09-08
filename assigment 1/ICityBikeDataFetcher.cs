using System.Threading.Tasks;
namespace assigment_1
{
    public interface ICityBikeDataFetcher
    {
        public Task<int> GetBikeCountInStation(string stationName);
    }
}