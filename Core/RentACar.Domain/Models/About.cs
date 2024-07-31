using RentACar.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Domain.Models
{
    public class About : BaseModel
    {
        public string Link { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
