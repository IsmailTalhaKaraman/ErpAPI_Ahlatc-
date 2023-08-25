using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpAPI.EEntity.DTO.LoginDTO
{
    public class LoginResponseDTO
    {
        public string AdSoyad { get; set; }
        public string EPosta { get; set; }
        public string Token { get; set; }
    }
}
