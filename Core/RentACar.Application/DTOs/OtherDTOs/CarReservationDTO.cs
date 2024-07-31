using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.DTOs.OtherDTOs
{
    public class CarReservationDTO
    {
        public Guid LocationStartId { get; set; }
        public Guid LocationEndId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
