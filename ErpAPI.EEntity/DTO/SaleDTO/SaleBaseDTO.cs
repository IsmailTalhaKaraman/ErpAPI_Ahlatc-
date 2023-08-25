using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpAPI.EEntity.DTO.SaleDTO
{
    public class SaleBaseDTO
    {
        public string SatisNo { get; set; }
        public double SatısFiyati { get; set; }
        public int MusteriID { get; set; }
        public int KullaniciID { get; set; }
        public int SiparisID { get; set; }
        public int OrderID { get; set; }
        public Guid CustomerGUID { get; set; }
        public string CustomerName { get; set; }
        public Guid Guid { get; set; }

    }
}
