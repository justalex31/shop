using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Entity
{
    public class User : BaseEntity
    {
        [Required(ErrorMessage = "Do not specify an email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Do not specify a password")]
        public string Password { get; set; }

        [Display(Name = "Role")]
        public Guid UserRoleID { get; set; }

        public UserRole UserRole { get; set; }

        public ICollection<Order> Orders { get; set; }
        public static object Identity { get; set; }

        public User()
        {
            Orders = new HashSet<Order>();
        }
    }
}
