using FluentValidation;
using RentACar.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Validators
{
    public class OptionValidator:AbstractValidator<OptionDTO>
    {

        public OptionValidator()
        {

            RuleFor(c => c.OpsiyonName).NotEmpty().WithMessage("Seçenek Adı Boş Geçilemez!!");
            RuleFor(c => c.OpsiyonPrice).NotEmpty().WithMessage("Seçenek Fiyatı Boş Geçilemez!!");
        }
    }
}
