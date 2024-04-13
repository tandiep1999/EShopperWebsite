using System.ComponentModel.DataAnnotations;

namespace WebShopCart.Models
{
    public class UserRegistrationModel
    {
        [Required(ErrorMessage = "User name is required")]
        public string user_name { get; set; }

        [Required(ErrorMessage = "E-mail is required")]
        public string email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string password { get; set; }

        [Compare(nameof(password), ErrorMessage = "Passwords do not match")]
        public string confirmPassword { get; set; }
    }
}
