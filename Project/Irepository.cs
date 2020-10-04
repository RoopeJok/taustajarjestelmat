using System;
using System.Threading.Tasks;
namespace Project
{
    public interface Irepository
    {
        Task<Player> Get(string id);
        Task<Player[]> GetAll();
        Task<Player> Create(Player player);
        Task<Player> Modify(string id, Player player);
        Task<Player> Delete(string id);
        Task<Player[]> GetAllPlayerScore();
        Task<Player> GetPlayerName(string name);
        Task<Player> UpdatePlayername(string oldname, string newname);
        Task<Player> Ban(string id, bool banned);
        Task<Player> GetPlayerScore(int score);
        Task<Player[]> GetBannedPlayers();
        Task<Player[]> GetNotBannedPlayers();
    }
}