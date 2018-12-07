using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Entity
{
    public class Rate : BaseEntity
    {
        [Range(typeof(Int32), "0", "5")]
        public int Rating { get; set; }

        [Display(Name = "User")]
        public Guid UserID { get; set; }

        [Display(Name = "User")]
        public Guid ProductID { get; set; }

        public User User { get; set; }

        public Product Product { get; set; }
    }
}