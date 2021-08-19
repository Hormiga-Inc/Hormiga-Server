using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data.MongoConfig
{
    public interface IMongoDbContext
    {
        //IMongoCollection<Product> Collection { get; } 
        IMongoCollection<T> GetCollection<T>(string namne);
    }
}
