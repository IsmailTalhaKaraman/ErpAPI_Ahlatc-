using ErpAPI.EEntity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpAPI.EEntity.Poco
{
    public class Authority:AuditableEntity
    {
        /*public Authority()
       {
           Users= new HashSet<User>();
       }*/
        public string Authorization { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }

        //public virtual IEnumerable<User> Users { get; set; }

    }
}
