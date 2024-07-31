using RentACar.Application.DTOs.BaseModelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.DTOs
{
    public class ReservationOptionDTO:BaseModelDTO
    {
        public Guid ReservationId { get; set; }
        public Guid OptionId { get; set; }
        public string? OptionName { get; set; }
        public int? OptionCount { get; set; }
        public decimal TotalOptionPrice { get; set; }
    }
}
