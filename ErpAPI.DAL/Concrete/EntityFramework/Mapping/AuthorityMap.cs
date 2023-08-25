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
    public class AuthorityMap:BaseMap<Authority>
    {
        public override void Configure(EntityTypeBuilder<Authority> builder)
        {
            builder.ToTable("Authority");
            builder.Property(q => q.Authorization).HasMaxLength(500).IsRequired();
            builder.HasOne(q => q.User).WithMany(q => q.Authorities).HasForeignKey(q => q.UserID).OnDelete(DeleteBehavior.NoAction);




        }
    }
}
