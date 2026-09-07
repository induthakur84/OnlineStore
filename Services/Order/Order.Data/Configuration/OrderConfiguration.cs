using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Domain;

namespace Order.Data.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<OrderTable>
    {
        public void Configure(EntityTypeBuilder<OrderTable> builder)
        {
            builder.HasOne(p=>p.User)
                .WithMany(o=>o.Orders)
                .HasForeignKey(o=>o.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
