using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Entity
{
    public class Catalog : BaseEntity
    {
        [Required(ErrorMessage = "Do not specify a name")]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }

        public Catalog()
        {
            Products = new HashSet<Product>();
        }
    }
}
