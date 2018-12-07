using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Entity
{
    public class Product : BaseEntity
    {
        [Required(ErrorMessage = "Do not specify a name")]
        public string Name { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Field of price must be more than 0")]
        public double Price { get; set; }

        [Display(Name = "Catalog")]
        public Guid CatalogID { get; set; }

        public Catalog Catalog { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<Rate> Rates { get; set; }

        public Product()
        {
            Orders = new HashSet<Order>();
            Rates = new HashSet<Rate>();
        }

    }
}
