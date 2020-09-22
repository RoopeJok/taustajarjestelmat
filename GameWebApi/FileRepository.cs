using System;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
namespace GameWebApi
{

    public class Listaaja
    {
        public Player[] Playerlist { get; set; }
        public Item[] ItemList { get; set; }
        public Listaaja(Player[] playerlist, Item[] itemList)
        {
            Playerlist = playerlist;
            ItemList = itemList;
        }
    }
    public class FileRepository : IRepository
    {
        string path = "game-dev.txt";

        public async Task<Player> Create(Player player)
        {
            Player[] players;
            Listaaja playerList = JsonConvert.DeserializeObject<Listaaja>(path);
            players = new Player[playerList.Playerlist.Length + 2];
            var createplayer = new Player
            {
                Id = player.Id,
                Name = player.Name,
                Score = player.Score,
                Level = player.Level,
                IsBanned = player.IsBanned,
                CreationTime = player.CreationTime
            };
            players = playerList.Playerlist;
            players[playerList.Playerlist.Length] = createplayer;
            string playerjson = JsonConvert.SerializeObject(player) + Environment.NewLine;
            try
            {
                await File.AppendAllTextAsync(path, playerjson, Encoding.UTF8);


                return player;

            }
            catch (ArgumentException e)
            {

                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<Item> CreateItem(Guid playerId, Item item)
        {
            Item[] items;
            Listaaja itemlist = JsonConvert.DeserializeObject<Listaaja>(path);
            items = new Item[itemlist.ItemList.Length + 2];
            playerId = new Guid();
            var createdItem = new Item
            {

                Id = item.Id,
                Name = item.Name,
                level = item.level
            };
            items = itemlist.ItemList;
            items[itemlist.ItemList.Length] = createdItem;
            string itemjson = JsonConvert.SerializeObject(item) + Environment.NewLine;
            try
            {
                await File.AppendAllTextAsync(path, itemjson, Encoding.UTF8);


                return item;

            }
            catch (ArgumentException e)
            {

                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<Player> Delete(Guid id)
        {
            Player player = new Player();
            string playerjson = JsonConvert.DeserializeObject(id.ToString()) + Environment.NewLine;
            try
            {
                if (path.Contains(id.ToString()))
                {
                    await File.WriteAllTextAsync(path, playerjson, Encoding.UTF8);
                    return player;
                }
                else
                {
                    return player;
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<Item> DeleteItem(Guid playerId, Item item)
        {
            string itemjson = JsonConvert.DeserializeObject(item.Id.ToString()) + Environment.NewLine;
            try
            {
                if (path.Contains(item.Id.ToString()) && path.Contains(playerId.ToString()))
                {
                    await File.WriteAllTextAsync(path, itemjson, Encoding.UTF8);
                    return item;
                }
                else
                {
                    return item;
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<Player> Get(Guid id)
        {
            Player player = new Player();
            try
            {
                if (path.Contains(id.ToString()))
                {
                    await File.ReadAllTextAsync(path);
                    return player;
                }
                else
                {
                    return player;
                }
            }
            catch (ArgumentException e)
            {

                Console.WriteLine(e.Message);
                throw;
            }
        }

        public Task<Player[]> GetAll()
        {
            Listaaja playerList = JsonConvert.DeserializeObject<Listaaja>(path);
            Player[] player = playerList.Playerlist;
            return Task.FromResult<Player[]>(player);
        }

        public Task<Item[]> GetAllItems(Guid playerId)
        {
            Listaaja itemList = JsonConvert.DeserializeObject<Listaaja>(path);
            Item[] item = itemList.ItemList;
            if (path.Contains(playerId.ToString()))
            {
                return Task.FromResult<Item[]>(item);
            }
            else
            {
                return null;
            }
        }

        public async Task<Item> GetItem(Guid playerId, Guid itemId)
        {
            Item itemi = new Item();
            try
            {
                if (path.Contains(itemId.ToString()) && path.Contains(playerId.ToString()))
                {
                    await File.ReadAllTextAsync(path);
                    return itemi;
                }
                else
                {
                    return itemi;
                }
            }
            catch (ArgumentException e)
            {

                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<Player> Modify(Guid id, ModifiedPlayer player)
        {
            Player player1 = new Player();
            string playerjson = JsonConvert.SerializeObject(id.ToString()) + Environment.NewLine;
            try
            {
                if (path.Contains(id.ToString()))
                {
                    await File.WriteAllTextAsync(path, playerjson, Encoding.UTF8);
                    return player1;
                }
                else
                {
                    return player1;
                }
            }
            catch (ArgumentException e)
            {

                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<Item> UpdateItem(Guid playerId, Item item)
        {

            string itemjson = JsonConvert.DeserializeObject(item.Id.ToString()) + Environment.NewLine;
            try
            {
                if (path.Contains(item.Id.ToString()) && path.Contains(playerId.ToString()))
                {
                    await File.WriteAllTextAsync(path, itemjson, Encoding.UTF8);
                    return item;
                }
                else
                {
                    return item;
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}