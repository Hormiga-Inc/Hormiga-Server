using Catalog.Core.Contracts.Repositories;
using Catalog.Core.Entities;
using Catalog.Infrastructure.Data.MongoConfig;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Data.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(IMongoDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string categoryId)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.CategoryId, categoryId);

            return await _collection
                                    .Find(filter)
                                    .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Name, name);

            return await _collection
                                .Find(filter)
                                .ToListAsync();
        }
    }
}
