using RentACar.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Domain.Models
{
    public class CarLocation:BaseModel
    {
        public Guid CarId { get; set; }
        public Car? Car { get; set; }
        public Guid LocationId { get; set; }
        public Location? Location { get; set; }
    }
}
