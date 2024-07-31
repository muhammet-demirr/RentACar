using Microsoft.Extensions.DependencyInjection;
using RentACar.Application.IServices;
using RentACar.Domain.Models;
using RentACar.Persistence.Services;
using RentACar.Persistence.Users;
using RentACarLocation.Application.IServices;
using RentAPartner.Application.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection service)
        {
            service.AddScoped<ICarLocationService, CarLocationService>();
            service.AddScoped<ICarOptionService, CarOptionService>();
            service.AddScoped<ICarService, CarService>();
            service.AddScoped<ILocationService, LocationService>();
            service.AddScoped<IOptionService, OptionService>();
            service.AddScoped<IReservationOptionService, ReservationOptionService>();
            service.AddScoped<IReservationService, ReservationService>();
            service.AddScoped<IServiceService, ServiceService>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IPartnerService, PartnerService>();
            service.AddScoped<IAboutService, AboutService>();
           
            return service;
        }
    }
}
