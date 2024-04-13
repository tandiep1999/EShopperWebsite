using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace WebShopCart.Models
{
    [PrimaryKey(nameof(user_id), nameof(email))]
    public class UserIdentity
    {
        public string user_id { get; set; }

        [Required]
        public string email { get; set; }

        public string user_name { get; set; }

        public string password { get; set; }

        public string? changed_at { get; set; }

        public string? changed_reason { get; set; }
    }
}
