using FluentValidation;
using RentACar.Application.DTOs.OtherDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Validators
{
    public class CarRezervationValidator:AbstractValidator<CarReservationDTO>
    {
        public CarRezervationValidator()
        {
            RuleFor(c=>c.EndDate).NotEmpty().WithMessage("Bitiş Tarihi Boş Geçilemez");
            RuleFor(c=>c.StartDate).NotEmpty().WithMessage("Başlangıç Tarihi Boş Geçilemez");
            RuleFor(c=>c.LocationStartId).NotEmpty().WithMessage("Başlangıç Lokasyonu Boş Geçilemez");
            RuleFor(c=>c.LocationEndId).NotEmpty().WithMessage("Bitiş Lokasyonu Boş Geçilemez");

        }
    }
}
