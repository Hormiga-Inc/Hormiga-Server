using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Dtos
{
    public class ProductDto : EntityDto
    {
        public string Name { get; set; }
        public string Detail { get; set; }
        public string CategoryId { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
    }
}
