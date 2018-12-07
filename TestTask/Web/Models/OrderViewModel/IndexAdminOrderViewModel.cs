using Core.Entity;
using Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.OrderViewModel
{
    public class IndexAdminOrderViewModel
    {
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Product")]
        public List<Product> Products { get; set; }

        [Display(Name = "Track #")]
        public Guid ID { get; set; }

        [Display(Name = "Status")]
        public ShipStatus ShipStatus { get; set; }
    }
}
