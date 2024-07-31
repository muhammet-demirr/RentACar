using FluentValidation;
using RentACar.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Validators
{
    public class ReservationValitador : AbstractValidator<ReservationDTO>
    {
        public ReservationValitador() 
        {
            RuleFor(c => c.RentPrice).NotEmpty().WithMessage("Kiralık Fiyat Boş Geçilemez!!");
            RuleFor(c => c.StartDate).NotEmpty().WithMessage("Başlangıç Tarihi Boş Geçilemez!!");
            RuleFor(c => c.EndDate).NotEmpty().WithMessage("Bitiş Tarihi Boş Geçilemez!!");
            RuleFor(c => c.Address).NotEmpty().WithMessage("Adres Boş Geçilemez!!");
            RuleFor(c => c.CustomerName).NotEmpty().WithMessage("Şirket Veya İsim Boş Geçilemez!!");
            RuleFor(c => c.IdentityNo).NotEmpty().WithMessage("Kimlik No Veya Pasaport Boş Geçilemez!!");
            RuleFor(c => c.PhoneNumber).NotEmpty().WithMessage("Telefon Numarası Boş Geçilemez!!").MinimumLength(10).WithMessage("Telefon Numarası En Az 10 Olmalı");
            RuleFor(c => c.Email).NotEmpty().WithMessage("Email Boş Geçilemez!!").EmailAddress().WithMessage("Mail Adresi Yanlış!!");

        }   

    }
}
