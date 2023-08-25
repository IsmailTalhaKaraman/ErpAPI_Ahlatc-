using ErpAPI.EEntity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpAPI.EEntity.Poco
{
    public class Customer:AuditableEntity
    {
        public Customer()
        {
            Sales = new HashSet<Sale>();
        }
        public string CustomerName { get; set; }
        public string CustomerTelephone { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerAdress { get; set; }
        public int SaleID { get; set; }

        public virtual IEnumerable<Sale> Sales { get; set; }
    }
}
