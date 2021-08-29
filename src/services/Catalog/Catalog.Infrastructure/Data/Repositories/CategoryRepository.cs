using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Core.Contracts.Repositories;
using Catalog.Core.Entities;
using Catalog.Infrastructure.Data.MongoConfig;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(IMongoDbContext context) : base(context)
        {
        }

    }
}
