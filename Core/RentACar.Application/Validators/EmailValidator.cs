using FluentValidation;
using RentACar.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Validators
{
    public class EmailValidator : AbstractValidator<EmailDTO>
    {
        public EmailValidator()
        {
            RuleFor(c => c.Message).NotEmpty().WithMessage("Mesaj Boş Geçilemez.");
            RuleFor(c => c.Phone).NotEmpty().WithMessage("Telefon Boş Geçilemez.").MinimumLength(10).WithMessage("Telefon Numarası En Az 10 Karakter Olmalı").MaximumLength(10).WithMessage("Telefon Numarası En Fazla 10 Karakter Olmalı");
            RuleFor(c => c.SurName).NotEmpty().WithMessage("Soyadı Boş Geçilemez.");
            RuleFor(c => c.Name).NotEmpty().WithMessage("Ad Boş Geçilemez.");
            RuleFor(c => c.Email).NotEmpty().WithMessage("Email Boş Geçilemez.").EmailAddress().WithMessage("Email Adresi Yanlış!!");
        }
    }
}
