using RentACar.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Domain.Models
{
    public class CarOption:BaseModel
    {
        public Guid CarId{ get; set; }
        public Car? Car { get; set; }
        public Guid OptionId { get; set; }
        public int? OptionCount { get; set; }
        public bool IsOption { get; set; }
        public Option? Option { get; set; }
    }
}
