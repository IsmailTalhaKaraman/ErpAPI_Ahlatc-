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
    public class PositionMap:BaseMap<Position>
    {
        public override void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.ToTable("Position");
            builder.Property(q => q.Duty).HasMaxLength(20).IsRequired();
        }
    }
}
