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
    public class SaleMap:BaseMap<Sale>
    {
        public override void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sale");
            builder.Property(q => q.SaleCode).HasMaxLength(10).IsRequired();
            //builder.HasOne(q=>q.User).WithMany(q=>q.Sales).HasForeignKey(q=>q.UserID).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(q => q.Customer).WithMany(q => q.Sales).HasForeignKey(q => q.CustomerID).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(q => q.Order).WithMany(q => q.Sales).HasForeignKey(q => q.OrderID).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
