using LobInkInterview.Config;
using LobInkInterview.DataAccess.Interfaces;
using LobInkInterview.DataAccess.Models;
using MongoDB.Driver;

namespace LobInkInterview.DataAccess
{

    public class DBContext : IDBContext
    {
        private readonly IMongoDatabase _db;
        public DBContext(MongoDBConfig config)
        {
            var client = new MongoClient(config.ConnectionString);
            _db = client.GetDatabase(config.Database);
        }
        public IMongoCollection<AdventureDefinitionDAL> AdventureDefinitions => _db.GetCollection<AdventureDefinitionDAL>("AdventureDefinitions");
        public IMongoCollection<AdventureDAL> Adventures => _db.GetCollection<AdventureDAL>("Adventures");
    }
}
