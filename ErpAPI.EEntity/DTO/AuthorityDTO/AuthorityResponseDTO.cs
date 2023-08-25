using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpAPI.EEntity.DTO.AuthorityDTO
{
    public class AuthorityResponseDTO:AuthorityBaseDTO
    {
        public Guid Guid { get; set; }
    }
}
