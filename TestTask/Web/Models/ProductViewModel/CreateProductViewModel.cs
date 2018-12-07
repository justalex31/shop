using System;

namespace Web.Models.ProductViewModel
{
    public class CreateProductViewModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Guid CatalogID { get; set; }
    }
}
