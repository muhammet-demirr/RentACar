using RentACar.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Domain.Models
{
    public class Reservation:BaseModel
    {
        public Guid CarId { get; set; }
        public  Car? Car { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid StartLocationId { get; set; }
        public Location? StartLocation { get; set; }
        public Guid EndLocationId { get; set; }
        public Location? EndLocation { get; set; }
        public decimal RentPrice { get; set; }
        public decimal? AdditionalProductPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string IdentityNo { get; set; }
        public string Address { get; set; }
        public string CustomerName { get; set; }
        public string? ArrivalFlightNo { get; set; }
        public string? ReturnFlightNumber { get; set; }

        public ICollection<ReservationOption>? ReservationOptions { get; set; }

    }
}
