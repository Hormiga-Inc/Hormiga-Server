using Catalog.Core.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data.MongoConfig
{
    public class MongoDbContext : IMongoDbContext
    {
        private IMongoClient client;
        private IMongoDatabase database;

        public MongoDbContext(IConfiguration configuration)
        {
            client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return database.GetCollection<T>(name);
        }
    }
}
