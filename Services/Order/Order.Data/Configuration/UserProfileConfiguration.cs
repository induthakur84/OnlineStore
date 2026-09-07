using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Data.Configuration
{
    public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            //one to one relationships


            builder.HasOne(p => p.User)
                .WithOne(up => up.UserProfile)
                .HasForeignKey<UserProfile>(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // for example user table (id=1; name=ram; email=indu@gmail.com)

            // userprofile (name= student; userid= 1
            // 

            //Restrict

            //one user to many relationship 

            // // for example user table (id=1; name=ram; email=indu@gmail.com)

            // order table (userid=1 ; 
        }
    }
}
