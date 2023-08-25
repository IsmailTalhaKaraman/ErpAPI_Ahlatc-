using ErpAPI.EEntity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpAPI.EEntity.Poco
{
    public class Product:AuditableEntity
    {
        public Product()
        {
            Orders = new HashSet<Order>();
        }
        public string Name { get; set; }

        public string ProductCode { get; set; }
        public double UnitPrice { get; set; }
        public virtual IEnumerable<Order> Orders { get; set; }
    }
}
