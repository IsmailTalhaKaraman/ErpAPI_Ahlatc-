using ErpAPI.EEntity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpAPI.EEntity.Poco
{
    public class Position:AuditableEntity
    {
        public Position()
        {
            Users = new HashSet<User>();
        }
        public string Duty { get; set; }

        public virtual IEnumerable<User> Users { get; set; }
    }
}
