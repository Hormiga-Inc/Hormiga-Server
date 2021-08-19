using Catalog.Core.Contracts;
using Catalog.Core.Contracts.Repositories;
using Catalog.Infrastructure.Data.MongoConfig;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : IEntity
    {
        protected readonly IMongoDbContext _context;
        protected IMongoCollection<TEntity> _collection;

        protected BaseRepository(IMongoDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _collection = context.GetCollection<TEntity>(typeof(TEntity).Name);

        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _collection
                                .Find(p => true)
                                .ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _collection
                                .Find(p => p.Id == id)
                                .FirstOrDefaultAsync();
        }


        public async Task CreateAsync(TEntity entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            var updateResult = await _collection.ReplaceOneAsync(filter: g => g.Id == entity.Id, replacement: entity);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _collection.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        

        
    }
}
