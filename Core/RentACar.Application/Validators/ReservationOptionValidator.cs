using FluentValidation;
using RentACar.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Validators
{
    public class ReservationOptionValidator : AbstractValidator<ReservationOptionDTO>
    {
        public ReservationOptionValidator() 
        {
            RuleFor(c => c.TotalOptionPrice).NotEmpty().WithMessage("Toplam Seçenek Fiyat Boş Geçilemez!!");
        }
    }
}
