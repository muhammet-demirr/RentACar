using FluentValidation;
using RentACar.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Validators
{
    public class PartnerValidator:AbstractValidator<PartnerDTO>
    {
        public PartnerValidator()
        {
            RuleFor(c => c.Image).NotEmpty().WithMessage("Referans resmi boş geçilemez.");
            RuleFor(c => c.PartnerName).NotEmpty().WithMessage("Referans ismi boş geçilemez.");

        }
    }
}
