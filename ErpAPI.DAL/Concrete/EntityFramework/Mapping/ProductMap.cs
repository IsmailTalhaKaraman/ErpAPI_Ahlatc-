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
    public class ProductMap:BaseMap<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.ProductCode).HasMaxLength(100).IsRequired();
            
    }
    }
}
