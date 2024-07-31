using RentACar.Application.DTOs.BaseModelDTOs;
using RentACar.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.DTOs
{
    public class CarDTO:BaseModelDTO
    {
        public string CarName { get; set; }
        public string CarModel { get; set; }
        public string? Photo { get; set; }
        public string Person { get; set; }
        public string Luggage { get; set; }
        public int Door { get; set; }
        public string gear { get; set; }
        public FuelType FuelType { get; set; }
        public string CarYear { get; set; }
        public decimal Depozit { get; set; }
        public string DrivingLicense { get; set; }
        public decimal? CarPrice { get; set; }
        public decimal TotalKm { get; set; }
        public bool IsAc { get; set; }
        public string CarNameModel => $"{CarName} {CarModel}";
    }
}
