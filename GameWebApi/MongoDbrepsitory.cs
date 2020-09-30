using System;
using System.Threading.Tasks;
using MongoDB.Bson;
using System.Linq;
using System.Collections.Generic;
using MongoDB.Driver;
using Newtonsoft.Json;
namespace GameWebApi
{
    public class MongoDbRepository : IRepository
    {
        private readonly IMongoCollection<Player> _playerCollection;
        private readonly IMongoCollection<BsonDocument> _bsonDocumentCollection;
        public MongoDbRepository()
        {
            var mongoClient = new MongoClient("Mongodb://localhost:27017");
            var database = mongoClient.GetDatabase("Game");
            _playerCollection = database.GetCollection<Player>("players");
            _bsonDocumentCollection = database.GetCollection<BsonDocument>("players");
        }
        public async Task<Player> Create(Player player)
        {
            await _playerCollection.InsertOneAsync(player);
            return player;
        }

        public async Task<Item> CreateItem(Guid playerId, Item item)
        {
            var filter = Builders<Player>.Filter.Eq(p => p.Id, playerId);
            Player player = await _playerCollection.Find(filter).FirstAsync();
            if (player == null)
            {
                throw new NotFoundException("Player not found");
            }
            if (player.itemlist == null)
            {
                player.itemlist = new List<Item>();
            }
            player.itemlist.Add(item);
            await _playerCollection.ReplaceOneAsync(filter, player);
            return item;
        }

        public async Task<Player> Delete(Guid id)
        {
            FilterDefinition<Player> filter = Builders<Player>.Filter.Eq(p => p.Id, id);
            return await _playerCollection.FindOneAndDeleteAsync(filter);
        }

        public async Task<Item> DeleteItem(Guid playerId, Item item)
        {
            var filter = Builders<Player>.Filter.Eq(p => p.Id, playerId);
            Player player = await _playerCollection.Find(filter).FirstAsync();
            Item item1 = null;
            for (int i = 0; i < player.itemlist.Count; i++)
            {
                if (player.itemlist[i].Id == item.Id)
                {
                    item1 = player.itemlist[i];
                    player.itemlist.RemoveAt(i);
                    await _playerCollection.ReplaceOneAsync(filter, player);
                    return item;
                }
            }
            return item1;
        }

        public async Task<Player> Get(Guid id)
        {
            var filter = Builders<Player>.Filter.Eq(p => p.Id, id);
            return await _playerCollection.Find(filter).FirstAsync();
        }

        public async Task<Player[]> GetAll()
        {
            var players = await _playerCollection.Find(new BsonDocument()).ToListAsync();
            return players.ToArray();
        }

        public async Task<Item[]> GetAllItems(Guid playerId)
        {
            var filter = Builders<Player>.Filter.Eq(p => p.Id, playerId);
            Player player = await _playerCollection.Find(filter).FirstAsync();
            return player.itemlist.ToArray();
        }

        public async Task<Item> GetItem(Guid playerId, Guid itemId)
        {
            var filter = Builders<Player>.Filter.Eq(p => p.Id, playerId);
            Player player = await _playerCollection.Find(filter).FirstAsync();
            for (int i = 0; i < player.itemlist.Count; i++)
            {
                if (player.itemlist[i].Id == itemId)
                {
                    return player.itemlist[i];
                }
            }
            return null;
        }

        public async Task<Player> Modify(Guid id, ModifiedPlayer player)
        {
            FilterDefinition<Player> filter = Builders<Player>.Filter.Eq(p => p.Id, id);
            Player player1 = await _playerCollection.Find(filter).FirstAsync();
            await _playerCollection.ReplaceOneAsync(filter, player1);
            return player1;
        }

        public async Task<Item> UpdateItem(Guid playerId, ModifiedItem item)
        {
            var filter = Builders<Player>.Filter.Eq(p => p.Id, playerId);
            Player player = await _playerCollection.Find(filter).FirstAsync();
            for (int i = 0; i < player.itemlist.Count; i++)
            {
                if (player.itemlist[i].Id == item.id)
                {
                    player.itemlist[i].level = item.level;
                    await _playerCollection.ReplaceOneAsync(filter, player);
                    return player.itemlist[i];
                }
            }
            return null;
        }
        public async Task<Player[]> GetPlayerScore(int minscore)
        {
            FilterDefinition<Player> filter = Builders<Player>.Filter.Gte(p => p.Score, minscore);
            List<Player> players = await _playerCollection.Find(filter).ToListAsync();
            return players.ToArray();
        }
        public async Task<Player> GetPlayerName(string name)
        {
            FilterDefinition<Player> filter = Builders<Player>.Filter.Eq(p => p.Name, name);
            return await _playerCollection.Find(filter).FirstAsync();
        }
        public async Task<Player[]> GetPlayerItem()
        {
            var filter = Builders<Player>.Filter.ElemMatch<Item>(p => p.itemlist, Builders<Item>.Filter.Eq(i => i.type, ItemType.Sword));
            List<Player> players = await _playerCollection.Find(filter).ToListAsync();
            return players.ToArray();
        }
        public async Task<Player> UpdatePlayername(string name, string name1)
        {
            var filter = Builders<Player>.Filter.Eq(p => p.Name, name);
            var update = Builders<Player>.Update.Set(p => p.Name, name1);
            await _playerCollection.UpdateOneAsync(filter, update);
            return null;
        }

    }
}