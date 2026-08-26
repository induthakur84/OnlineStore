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

       
    }
}