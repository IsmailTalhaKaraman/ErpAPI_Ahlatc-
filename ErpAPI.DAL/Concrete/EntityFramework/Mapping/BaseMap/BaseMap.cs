
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ErpAPI.EEntity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpAPI.DAL.Concrete.EntityFramework.Mapping.BaseMap
{
    public class BaseMap<T> : IEntityTypeConfiguration<T> where T : AuditableEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(q => q.ID);
            builder.Property(q => q.ID).ValueGeneratedOnAdd();
            builder.Property(q => q.Guid).ValueGeneratedOnAdd();
        }
    }
}
