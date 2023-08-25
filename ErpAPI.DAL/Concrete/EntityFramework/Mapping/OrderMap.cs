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
    public class OrderMap:BaseMap<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
          
            builder.Property(q => q.OrderCode).HasMaxLength(10).IsRequired();
          
            
            builder.HasOne(q => q.Product).WithMany(q => q.Orders).HasForeignKey(q => q.ProductID).OnDelete(DeleteBehavior.NoAction);
        }
    }

}
