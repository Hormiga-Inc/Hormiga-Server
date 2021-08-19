namespace Catalog.Core.Entities
{
    public class Product : Catalog
    {
   
        public string Name { get; set; }
        public string Detail { get; set; }
        public string CategoryId { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
    }
}
