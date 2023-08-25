using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpAPI.EEntity.DTO.ProductDTO
{
    public class ProductBaseDTO
    {
        public string UrunAdi { get; set; }

        public string UrunKodu { get; set; }
        public double BirimFiyat { get; set; }
    }
}
