using Core.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Entity
{
    public class Order : BaseEntity
    {
        [Display(Name = "User")]
        public Guid UserID { get; set; }

        [Display(Name = "Product")]
        public Guid ProductID { get; set; }

        public User User { get; set; }

        public Product Product { get; set; }

        [Display(Name = "TypeShip")]
        public TypeShip TypeShip { get; set; }

        [Display(Name = "ShipStatus")]
        public ShipStatus ShipStatus { get; set; }
    }
}
