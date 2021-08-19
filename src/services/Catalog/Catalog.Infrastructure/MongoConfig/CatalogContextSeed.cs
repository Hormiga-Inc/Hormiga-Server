
using Catalog.Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Data.MongoConfig
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();

            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetPreconfiguratedProducts());
            }
        }

        private static IEnumerable<Product> GetPreconfiguratedProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Motorola One XP",
                    Detail = "Telefono Mobil de alta gama",
                    CategoryId= "iohohiohoihoihodfe3543ef",
                    Price = 2568.566M,
                    Cost = 56654.656M,
                    ImageUrl = "motorola.png"
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nokia One XP",
                    Detail = "Telefono Mobil de alta gama",
                    CategoryId= "iohohiohoihoihodfe3543ef",
                    Price = 2568.566M,
                    Cost = 56654.656M,
                    ImageUrl = "motorola.png"
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Iphone One XP",
                    Detail = "Telefono Mobil de alta gama",
                    CategoryId= "iohohiohoihoihodfe3543ef",
                    Price = 2568.566M,
                    Cost = 56654.656M,
                    ImageUrl = "motorola.png"
                }
            };
        }
    }
}
