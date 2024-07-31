using RentACar.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Domain.Models
{
    public class ReservationOption:BaseModel
    {
        public Guid ReservationId { get; set; }
        public virtual Reservation? Reservation { get; set; }
        public Guid OptionId { get; set; }
        public Option? Option { get; set; }
        public int? OptionCount { get; set; }
        public decimal TotalOptionPrice { get; set; }
    }
}
