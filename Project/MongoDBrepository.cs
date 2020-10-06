using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
namespace Project
{
    public class MongoDBrepository : Irepository
    {
        private readonly IMongoCollection<Player> _playerCollection;
        private readonly IMongoCollection<BsonDocument> _bsonDocumentCollection;
        public MongoDBrepository()
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var database = mongoClient.GetDatabase("Game");
            _playerCollection = database.GetCollection<Player>("Game");
            _bsonDocumentCollection = database.GetCollection<BsonDocument>("Game");
        }

        public async Task<Player> Ban(Player player)
        {
            var filter = Builders<Player>.Filter.Eq(p => p.Id, player.Id);
            var update = Builders<Player>.Update.Set(p => p.IsBanned, player.IsBanned);
            await _playerCollection.UpdateOneAsync(filter, update);
            return null;
        }

        public async Task<Player> Create(Player player)
        {
            await _playerCollection.InsertOneAsync(player);
            return player;
        }

        public async Task<Player> Delete(Player player)
        {
            FilterDefinition<Player> filter = Builders<Player>.Filter.Eq(p => p.Id, player.Id);
            return await _playerCollection.FindOneAndDeleteAsync(filter);
        }

        public Task<Player> Get(Player player)
        {
            var filter = Builders<Player>.Filter.Eq(p => p.Id, player.Id);
            return _playerCollection.Find(filter).FirstAsync();
        }

        public async Task<Player[]> GetAll()
        {
            var players = await _playerCollection.Find(new BsonDocument()).ToListAsync();
            return players.ToArray();
        }

        public async Task<Player[]> GetAllPlayerScore()
        {
            var sort = Builders<Player>.Sort.Descending(p => p.Score);
            var players = await _playerCollection.Find(new BsonDocument()).Sort(sort).ToListAsync();
            return players.ToArray();
        }

        public async Task<Player[]> GetBannedPlayers(Player player)
        {
            var filter = Builders<Player>.Filter.Eq(p => p.IsBanned, player.IsBanned);
            var players = await _playerCollection.Find(filter).ToListAsync();
            return players.ToArray();
        }

        public async Task<Player[]> GetNotBannedPlayers(Player player)
        {
            var filter = Builders<Player>.Filter.Ne(p => p.IsBanned, player.IsBanned);
            var players = await _playerCollection.Find(filter).ToListAsync();
            return players.ToArray();
        }

        public async Task<Player> GetPlayerName(Player player)
        {
            var filter = Builders<Player>.Filter.Eq(p => p.Name, player.Name);
            return await _playerCollection.Find(filter).FirstAsync();
        }

        public async Task<Player> GetPlayerScore(Player player)
        {
            var filter = Builders<Player>.Filter.Eq(p => p.Score, player.Score);
            return await _playerCollection.Find(filter).FirstAsync();
        }

        public async Task<Player> Modify(Player player)
        {
            var filter = Builders<Player>.Filter.Eq(p => p.Id, player.Id);
            await _playerCollection.ReplaceOneAsync(filter, player);
            return player;
        }

        public async Task<Player> UpdatePlayername(Player player, string newname)
        {
            var filter = Builders<Player>.Filter.Eq(p => p.Name, player.Name);
            var update = Builders<Player>.Update.Set(p => p.Name, newname);
            await _playerCollection.UpdateOneAsync(filter, update);
            return null;
        }


    }

}