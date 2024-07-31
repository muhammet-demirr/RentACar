using RentACar.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Domain.Models
{
    public class Location:BaseModel
    {
        public string City { get; set; }
        public ICollection<CarLocation>? CarLocations { get; set; }
        public ICollection<Reservation>? StartLocations { get; set; }
        public ICollection<Reservation>? EndLocations { get; set; }

    }
}
