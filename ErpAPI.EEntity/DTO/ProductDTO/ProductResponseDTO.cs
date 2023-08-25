using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpAPI.EEntity.DTO.ProductDTO
{
    public class ProductResponseDTO:ProductBaseDTO
    {
        public Guid Guid { get; set; }
    }
}
