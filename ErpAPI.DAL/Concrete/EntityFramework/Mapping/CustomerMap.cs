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
    public class CustomerMap:BaseMap<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");
            builder.Property(q => q.CustomerAdress).HasMaxLength(500).IsRequired();
            builder.Property(q => q.CustomerName).HasMaxLength(100).IsRequired();
            builder.Property(q=>q.CustomerEmail).HasMaxLength(100).IsRequired();
            builder.Property(q=>q.CustomerTelephone).HasMaxLength(20).IsRequired();
            
            
        }
    }
}
