using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpAPI.EEntity.DTO.CustomerDTO
{
    public class CustomerBaseDTO
    {
        public string MusteriAdi { get; set; }
        public string MusterTelefon { get; set; }
        public string MusterEposta { get; set; }
        public string MusteriAdres { get; set; }
        public int SatısNo { get; set; }
        public Guid Guid { get; set; }

    }
}
