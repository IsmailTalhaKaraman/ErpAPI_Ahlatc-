using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpAPI.EEntity.DTO.OrdetDTO
{
    public class OrderResponseDTO:OrderBaseDTO
    {
        public Guid Guid { get; set; }
    }
}
