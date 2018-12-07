using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Entity
{
    public class UserRole : BaseEntity
    {
        [Required(ErrorMessage = "Do not specify a name")]
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }

        public UserRole()
        {
            Users = new HashSet<User>();
        }
    }
}
