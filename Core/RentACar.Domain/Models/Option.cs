using RentACar.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Domain.Models
{
    public class Option:BaseModel
    {
        public string OpsiyonName { get; set; }
        public decimal OpsiyonPrice { get; set; }
        public ICollection<CarOption>? CarOptions { get; set; }
        public ICollection<ReservationOption>? ReservationOptions { get; set; }
    }
}
