using RentACar.Application.DTOs.BaseModelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.DTOs
{
    public class ReservationDTO:BaseModelDTO
    {
        public Guid CarId { get; set; }
        public string? CarName { get; set; }
        public string? CarModel { get; set; }
        public Guid StartLocationId { get; set; }
        public string? StartLocationAdress { get; set; }
        public Guid EndLocationId { get; set; }
        public string? EndLocationAdress { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal RentPrice { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string CustomerName { get; set; }
        public string? ArrivalFlightNo { get; set; }
        public string IdentityNo { get; set; }
        public string? ReturnFlightNumber { get; set; }
        public decimal? AdditionalProductPrice { get; set; }
        public decimal? TotalPrice { get; set; }
    }
}
