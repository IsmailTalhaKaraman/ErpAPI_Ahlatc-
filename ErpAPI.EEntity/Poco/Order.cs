using ErpAPI.EEntity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpAPI.EEntity.Poco
{
    public class Order:AuditableEntity
    {
        public Order()
        {
            Sales = new HashSet<Sale>();
        }

        public int SaleID { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public double Quantity { get; set; }
        public string OrderCode { get; set; }
        public int OrderSalesCode { get; set; }
        public double TotalPrice { get; set; }
        // public virtual Sale Sale { get; set; }
        public virtual User User { get; set; }
        public virtual Product Product { get; set; }

        public virtual IEnumerable<Sale> Sales { get; set; }
    }
}
