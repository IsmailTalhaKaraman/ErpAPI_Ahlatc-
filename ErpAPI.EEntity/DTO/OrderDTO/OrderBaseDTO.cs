using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpAPI.EEntity.DTO.OrdetDTO
{
    public class OrderBaseDTO
    {
        public int SatısID { get; set; }
        public int KullanıcıID { get; set; }
        public int Urun { get; set; }
        public double SiparisAciklamasi { get; set; }
        public string SiparisKodu { get; set; }
        public int SatisSiparisKodu { get; set; }
        public double ToplamFiyat { get; set; }
    }
}
