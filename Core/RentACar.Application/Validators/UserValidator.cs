using FluentValidation;
using RentACar.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Validators
{
    public class UserValidator : AbstractValidator<UserDTO>
    {
        public UserValidator()
        {
            RuleFor(c => c.FirstName).NotEmpty().WithMessage("İsim Boş Geçilemez!!");
            RuleFor(c => c.LastName).NotEmpty().WithMessage("Soy İsim Boş Geçilemez!!");
            RuleFor(c => c.EMailAddress).NotEmpty().WithMessage("E-Mail adres Boş Geçilemez!!");
            RuleFor(c => c.Password).NotEmpty().WithMessage("Şifre Boş Geçilemez!!");
            

        }
    }
}
