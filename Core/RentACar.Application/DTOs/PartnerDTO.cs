using RentACar.Application.DTOs.BaseModelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.DTOs
{
    public class PartnerDTO:BaseModelDTO
    {
        public string Image { get; set; }
        public string PartnerName { get; set; }
    }
}
