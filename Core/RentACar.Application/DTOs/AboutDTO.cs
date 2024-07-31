using RentACar.Application.DTOs.BaseModelDTOs;
using RentACar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.DTOs
{
    public class AboutDTO : BaseModelDTO
    {
        public string Link { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
