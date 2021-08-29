
using Catalog.API.Dtos;
using Catalog.Core.Contracts.Repositories;
using Catalog.Core.Contracts.Services;
using Catalog.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Catalog.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ICategoryService service, ILogger<CategoryController> logger)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));    
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Category>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var Categories = await _service.GetAllAsync(); 
            return Ok(Categories);
        }

        [HttpGet("{id}", Name = "GetCategoryById")]
        [ProducesResponseType((int)HttpStatusCode.NotFound )]
        [ProducesResponseType(typeof(Category), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Category>> GetCategoryById(Guid id)
        {
            var Category = await _service.GetByIdAsync(id);

            if(Category == null)
            {
                _logger.LogError($"Categoryo con id: {id}, no fue encontrado");
                return NotFound();
            }

            return Ok(Category);
        }

       

        [HttpPost]
        [ProducesResponseType(typeof(Category), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Category>> CreateCategory([FromBody] Category Category)
        {
            await _service.CreateAsync(Category);

            return CreatedAtRoute("GetCategoryById", new { id = Category.Id }, Category);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Category), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> UpdateCategory([FromBody] Category Category)
        {

            return Ok(await _service.UpdateAsync(Category));
        }

        [HttpDelete("{id}", Name = "DeleteCategory")]
        [ProducesResponseType(typeof(Category), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> DeleteCategory(Guid id)
        {

            return Ok(await _service.DeleteAsync(id));
        }
    }
}
