using ErpAPI.EEntity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpAPI.EEntity.Poco
{
    public class User:AuditableEntity
    {
        public User()
        {
            /* if (PositionID == 1)
             {
                 Sales = new HashSet<Sale>();
             }
             else
             {
                 Orders = new HashSet<Order>();
             }*/

            Authorities = new HashSet<Authority>();
        }



        public string FirstName { get; set; }

        public string LastName { get; set; }
        public int PositionID { get; set; }
        public string Pasword { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string UserName { get; set; }
        public int AuthorityID { get; set; }
        public virtual Position Position { get; set; }
        // public virtual IEnumerable<Sale> Sales { get; set; }
        // public virtual IEnumerable<Order> Orders  { get; set; }     
        public virtual IEnumerable<Authority> Authorities { get; set; }
    }
}
