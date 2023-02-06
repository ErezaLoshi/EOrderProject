using EOrderProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EOrderProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Menu>Menus { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Issues> Issues { get; set; }

        public DbSet<ComingSoon> ComingSoon { get; set; }
    }
}