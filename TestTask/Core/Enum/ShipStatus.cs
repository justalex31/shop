using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Enum
{
    public enum ShipStatus
    {
        [Display(Name = "Подготовка")]
        Packaging = 1,
        [Display(Name = "Перевозка")]
        Transit = 2,
        [Display(Name = "Доставлен")]
        Delivered = 3
    }
}
