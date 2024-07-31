using RentACar.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Domain.Models
{
    public class Service:BaseModel
    {
        public string ServiceName { get; set; }
        public string Icon { get; set; }
        public string ServiceDescription { get; set; }
    }
}
