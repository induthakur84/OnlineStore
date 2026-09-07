using Microsoft.EntityFrameworkCore;
using Order.Domain;

namespace Order.Data.Context
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(
            DbContextOptions<OrderDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<UserProfile> UserProfiles { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<OrderTable> Orders { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}