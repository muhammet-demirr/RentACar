using RentACar.Application.DTOs.BaseModelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.DTOs
{
    public class CarOptionDTO:BaseModelDTO
    {
        public Guid CarId { get; set; }
        public Guid OptionId { get; set; }
        public string? CarName { get; set; }
        public string? CarModel { get; set; }
        public string? OptionName { get; set; }
        public decimal? OptionPrice { get; set; }
        public bool IsOption { get; set; }
        public int? OptionCount { get; set; }
    }
}
