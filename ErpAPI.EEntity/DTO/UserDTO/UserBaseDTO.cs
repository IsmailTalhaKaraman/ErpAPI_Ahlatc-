using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpAPI.EEntity.DTO.UserDTO
{
    public class UserBaseDTO
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string Eposta { get; set; }
        public string Telefon { get; set; }
        public int Görev { get; set; }
    }
}
