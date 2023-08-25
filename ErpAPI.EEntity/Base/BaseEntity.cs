using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpAPI.EEntity.Base
{
    public class BaseEntity
    {
        public int ID { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
    }
}
