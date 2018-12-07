using System.ComponentModel.DataAnnotations;

namespace Web.Models.AccountViewModel
{
    public class LoginModel
    {
        [Display(Name = "Login")]
        [Required(ErrorMessage = "Do not specify a email")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Do not specify a password")]
        public string Password { get; set; }
    }
}
