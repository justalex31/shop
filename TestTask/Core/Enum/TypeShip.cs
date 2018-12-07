using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Enum
{
    public enum TypeShip
    {
        [Display(Name = "Самовывоз")]
        Pickup = 1,
        [Display(Name = "Доставка")]
        Delivery = 2
    }
}
