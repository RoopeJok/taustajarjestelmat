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
        public async Task<Player> Create(Player player)
        {
            await _playerCollection.InsertOneAsync(player);
            return player;
        }

        public async Task<Player> Delete(string id)
        {
            FilterDefinition<Player> filter = Builders<Player>.Filter.Eq(p => p.Id, id);
            return await _playerCollection.FindOneAndDeleteAsync(filter);
        }

        public Task<Player> Get(string id)
        {
            var filter = Builders<Player>.Filter.Eq(p => p.Id, id);
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

        public async Task<Player[]> GetBannedPlayers()
        {
            var filter = Builders<Player>.Filter.Eq(p => p.IsBanned, true);
            var players = await _playerCollection.Find(filter).ToListAsync();
            return players.ToArray();
        }

        public async Task<Player[]> GetNotBannedPlayers()
        {
            var filter = Builders<Player>.Filter.Eq(p => p.IsBanned, false);
            var players = await _playerCollection.Find(filter).ToListAsync();
            return players.ToArray();
        }

        public async Task<Player> GetPlayerName(string name)
        {
            var filter = Builders<Player>.Filter.Eq(p => p.Name, name);
            return await _playerCollection.Find(filter).FirstAsync();
        }

        public async Task<Player> GetPlayerScore(int score)
        {
            var filter = Builders<Player>.Filter.Eq(p => p.Score, score);
            return await _playerCollection.Find(filter).FirstAsync();
        }

        public async Task<Player> Modify(Player player)
        {
            var filter = Builders<Player>.Filter.Eq(p => p.Id, player.Id);
            await _playerCollection.ReplaceOneAsync(filter, player);
            return player;
        }

        public async Task<Player> UnBan(string id)
        {
            var filter = Builders<Player>.Filter.Eq(p => p.Id, id);
            var update = Builders<Player>.Update.Set(p => p.IsBanned, false);
            await _playerCollection.UpdateOneAsync(filter, update);
            return null;
        }
        public async Task<Player> Ban(string id)
        {
            var filter = Builders<Player>.Filter.Eq(p => p.Id, id);
            var update = Builders<Player>.Update.Set(p => p.IsBanned, true);
            await _playerCollection.UpdateOneAsync(filter, update);
            return null;
        }

        public async Task<Player> UpdatePlayername(string name, string newname)
        {
            var filter = Builders<Player>.Filter.Eq(p => p.Name, name);
            var update = Builders<Player>.Update.Set(p => p.Name, newname);
            await _playerCollection.UpdateOneAsync(filter, update);
            return null;
        }


    }

}