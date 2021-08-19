using Catalog.Core.Contracts;
using Catalog.Core.Contracts.Repositories;
using Catalog.Core.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Core.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : IEntity
    {
        private readonly IBaseRepository<TEntity> _repository;

        public BaseService(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public Task<TEntity> GetByIdAsync(Guid id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task CreateAsync(TEntity entity)
        {
            return _repository.CreateAsync(entity);
        }

        public Task<bool> UpdateAsync(TEntity entity)
        {
            return _repository.UpdateAsync(entity);
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            return _repository.DeleteAsync(id);
        }

        

        
    }
}
