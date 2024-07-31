using FluentValidation;
using RentACar.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Validators
{
    public class LocationValidator:AbstractValidator<LocationDTO>
    {

        public LocationValidator() 
        {
            RuleFor(c => c.City).NotEmpty().WithMessage("Şehir Alanı Boş Bırakılamaz");
            RuleFor(c => c.Decription).NotEmpty().WithMessage("Lokasyon Alanı Boş Bırakılamaz");
        }
    }
}
