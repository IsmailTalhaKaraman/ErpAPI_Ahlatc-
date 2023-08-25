using ErpAPI.EEntity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpAPI.EEntity.Poco
{
    public class Sale:AuditableEntity
    {

        public string SaleCode { get; set; }
        public double SalePrice { get; set; }
        public int CustomerID { get; set; }
        public int UserID { get; set; }
        public int OrderID { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual User User { get; set; }
        public virtual Order Order { get; set; }
    }
}
