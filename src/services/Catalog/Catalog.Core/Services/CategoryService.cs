using Catalog.Core.Contracts.Repositories;
using Catalog.Core.Contracts.Services;
using Catalog.Core.Entities;

namespace Catalog.Core.Services
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        private readonly ICategoryRepository _repository;
        public CategoryService(ICategoryRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}