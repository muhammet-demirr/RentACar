using RentACar.Application.DTOs.BaseModelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.DTOs
{
    public class CarLocationDTO:BaseModelDTO
    {
        public Guid CarId { get; set; }
        public Guid LocationId { get; set; }
        public string? CarName { get; set; }
        public string? CarModel { get; set; }
        public string? City { get; set; }
        public string? LocationDescription { get; set; }
    }
}
