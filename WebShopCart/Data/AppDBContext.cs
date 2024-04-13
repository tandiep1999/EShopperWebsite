using Microsoft.EntityFrameworkCore;
using WebShopCart.Models;

namespace WebShopCart.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }
        public DbSet<User>? Users { get; set; }

        public DbSet<UserIdentity>? User_Identity { get; set; }
    }
}