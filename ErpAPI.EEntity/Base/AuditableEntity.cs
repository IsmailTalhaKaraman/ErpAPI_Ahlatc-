using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpAPI.EEntity.Base
{
    public class AuditableEntity:BaseEntity
    {
        public DateTime AddTime { get; set; }
        public int AddUser { get; set; }
        public DateTime UpdatedTime { get; set; }
        public int UpdatedUser { get; set; }
        public string AddedIPV4Adress { get; set; }
        public string UpdatedAIPV4Adress { get; set; }
    }
}
