using FluentValidation;
using RentACar.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Validators
{
    public class ServiceValidator : AbstractValidator<ServiceDTO>
    {
        public ServiceValidator()
        {
            RuleFor(c => c.ServiceName).NotEmpty().WithMessage("Servsis Adı Boş Geçilemez!!");

        }
    }
}
