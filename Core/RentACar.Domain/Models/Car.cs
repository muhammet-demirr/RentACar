using RentACar.Domain.Enums;
using RentACar.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Domain.Models
{
    public class Car : BaseModel
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
        public ICollection<CarOption>? CarOptions { get; set; }
        public ICollection<CarLocation>? CarLocations { get; set; }
        public ICollection<Reservation>? Reservations { get; set; }

    }
}
