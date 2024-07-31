using FluentValidation;
using RentACar.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Validators
{
    public class CarOptionValidator: AbstractValidator<CarOptionDTO>
    {
        public CarOptionValidator()
        {
            RuleFor(c => c.CarId).NotEmpty().WithMessage("Araba Adı Boş Geçilemez!!");
            RuleFor(c => c.OptionId).NotEmpty().WithMessage("Seçenek Boş Geçilemez!!");
          
        } 
    }
}
