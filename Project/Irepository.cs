using System;
using System.Threading.Tasks;
namespace Project
{
    public interface Irepository
    {
        Task<Player> Get(Player player);
        Task<Player[]> GetAll();
        Task<Player> Create(Player player);
        Task<Player> Modify(Player player);
        Task<Player> Delete(Player player);
        Task<Player[]> GetAllPlayerScore();
        Task<Player> GetPlayerName(Player player);
        Task<Player> UpdatePlayername(Player player, string newname);
        Task<Player> Ban(Player player);
        Task<Player> GetPlayerScore(Player player);
        Task<Player[]> GetBannedPlayers(Player player);
        Task<Player[]> GetNotBannedPlayers(Player player);
    }
}