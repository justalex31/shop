using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models.ProductViewModel
{
    public class IndexProductViewModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        [Display(Name = "Catalog")]
        public string NameCatalog { get; set; }
        public double Rating { get; set; }
    }
}
