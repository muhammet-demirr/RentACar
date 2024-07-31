using FluentValidation;
using RentACar.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Validators
{
    public class CarValidator:AbstractValidator<CarDTO>
    {
        public CarValidator()
        {
            RuleFor(c=>c.CarName).NotEmpty().WithMessage("Araba Adı Boş Geçilemez!!");
            RuleFor(c => c.CarModel).NotEmpty().WithMessage("Araba Modeli Boş Geçilemez!!");
            RuleFor(c => c.Photo).NotEmpty().WithMessage("Fotoğraf Alanı Boş Geçilemez!!");
            RuleFor(c => c.Person).NotEmpty().WithMessage("Kişi Alanı Boş Geçilemez!!");
            RuleFor(c => c.Luggage).NotEmpty().WithMessage("Bağaj Alanı Boş Geçilemez!!");
            RuleFor(c => c.Door).NotEmpty().WithMessage("Kapı Alanı Boş Geçilemez!!");
            RuleFor(c => c.gear).NotEmpty().WithMessage("Vites Alanı Boş Geçilemez!!");
            RuleFor(c => c.FuelType).NotEmpty().WithMessage("Yakıt Tipi Alanı Boş Geçilemez!!");
            RuleFor(c => c.CarYear).NotEmpty().WithMessage("Araba Yıl Alanı Boş Geçilemez!!");
            RuleFor(c => c.Depozit).NotEmpty().WithMessage("Depozito Alanı Boş Geçilemez!!");
            RuleFor(c => c.CarPrice).NotEmpty().WithMessage("Fiyat Alanı Boş Geçilemez!!");

            RuleFor(c => c.TotalKm).NotEmpty().WithMessage("Total Km Alanı Boş Geçilemez!!");
            
        }
    }
}
