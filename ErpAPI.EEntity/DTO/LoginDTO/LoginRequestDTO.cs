using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpAPI.EEntity.DTO.LoginDTO
{
    public class LoginRequestDTO
    {
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
    }
}
