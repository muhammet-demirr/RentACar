using FluentValidation;
using RentACar.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Validators
{
    public class AboutValidator: AbstractValidator<AboutDTO>
    {
        public AboutValidator()
        {
            RuleFor(c => c.Link).NotEmpty().WithMessage("Link Boş Geçilemez.");
            RuleFor(c => c.Text).NotEmpty().WithMessage("Hakkımızda alanı boş geçilemez.");
            RuleFor(c => c.Title).NotEmpty().WithMessage("Başlık boş geçilemez.");
        }
    }
}
