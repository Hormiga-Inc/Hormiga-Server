using Catalog.API.Dtos;
using Catalog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Extensions
{
    public static class ProductExtension
    {
        public static ProductDto AsProductDto(this Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Detail = product.Detail,
                CategoryId = product.CategoryId,
                Cost = product.Cost,
                Price = product.Price
            };
        } 
    }
}
