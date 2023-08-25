using ErpAPI.DAL.Concrete.EntityFramework.Mapping.BaseMap;
using ErpAPI.EEntity.Poco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpAPI.DAL.Concrete.EntityFramework.Mapping
{
    public class UserMap:BaseMap<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.Property(q => q.UserName).HasMaxLength(50).IsRequired();
            builder.Property(q => q.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(q=>q.LastName).HasMaxLength(50).IsRequired();
            builder.Property(q => q.Email).HasMaxLength(100).IsRequired();
            builder.Property(q => q.Phone).HasMaxLength(20).IsRequired();
            builder.HasOne(q=>q.Position).WithMany(q=>q.Users).HasForeignKey(q=>q.PositionID).OnDelete(DeleteBehavior.NoAction);
          //  builder.HasOne(q => q.Authority).WithMany(q => q.Users).HasForeignKey(q => q.AuthorityID).OnDelete(DeleteBehavior.NoAction);
               
        }
    }
}

