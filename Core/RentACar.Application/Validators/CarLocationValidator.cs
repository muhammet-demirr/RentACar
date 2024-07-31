using FluentValidation;
using RentACar.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Validators
{
    public class CarLocationValidator:AbstractValidator<CarLocationDTO>
    {
        public CarLocationValidator() 
        {
            RuleFor(c => c.CarId).NotEmpty().WithMessage("Araba Adı Boş Geçilemez!!");
            RuleFor(c => c.LocationId).NotEmpty().WithMessage("Lokasyon Adı Boş Geçilemez!!");

        }
    }
}
