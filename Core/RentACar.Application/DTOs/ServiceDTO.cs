using RentACar.Application.DTOs.BaseModelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.DTOs
{
    public class ServiceDTO:BaseModelDTO
    {
        public string ServiceName { get; set; }
        public string Icon { get; set; }
        public string ServiceDescription { get; set; }
    }
}
