using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RentACar.Application.DTOs;
using RentACar.Application.DTOs.OtherDTOs;
using RentACar.Application.IServices;
using RentACar.Domain.Models;
using RentACar.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.Services
{
    public class CarService : ICarService
    {
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly RentACarPsqlDbContext context;
        public  CarService(IMapper _mapper,IConfiguration _configuration,RentACarPsqlDbContext _context)
        {
            mapper= _mapper;
            configuration=_configuration;
            context= _context;
        }
        public async Task<CarDTO> CreateCar(CarDTO Car)
        {
           var dbCar = await context.Cars.Where(c => c.Id == Car.Id).FirstOrDefaultAsync();
            if (dbCar != null)
                throw new Exception("Bu Araba Zaten Sistemde Kayıtlı");
            dbCar = mapper.Map<Car>(Car);
            dbCar.CreateDate = DateTime.Now;
            await context.Cars.AddAsync(dbCar);
            int result = await context.SaveChangesAsync();

            return mapper.Map<CarDTO>(dbCar);
            
        }

        public async Task<bool> DeleteCarId(Guid id)
        {
            var dbCar =await context.Cars.Where(c=>c.Id==id).FirstOrDefaultAsync();
            if (dbCar == null)
                throw new Exception("Araba Bulunamadı");
            context.Cars.Remove(dbCar);
            int result= await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<CarDTO> GetCarById(Guid Id)
        {
            var dbCar= await context.Cars.Where(c => c.Id == Id)
                .ProjectTo<CarDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
            if (dbCar == null)
                throw new Exception("Araba Bulunamadı.");
            return dbCar;
        }

        public async Task<List<CarDTO>> GetCarReservations(string startDate, string endDate)
        {
            List<CarDTO> carDTOs= new List<CarDTO>();
           
          var cars= await context.Cars.ProjectTo<CarDTO>(mapper.ConfigurationProvider).ToListAsync();
            foreach (var car in cars)
            {
                var reservation = await context.Reservations.Where(c => c.CarId == car.Id).OrderByDescending(c=>c.Id).FirstOrDefaultAsync();
                if (reservation is not null )
                {
                    var sagStartDate = DateTime.Parse(startDate);
                    var sagEndDate = DateTime.Parse(endDate);
                    var solEndCarDate = DateTime.Parse(reservation.EndDate.ToString("dd.MM.yyyy"));
                    var sagStartCarDate = DateTime.Parse(reservation.StartDate.ToString("dd.MM.yyyy"));
                    if (!(sagEndDate < sagStartCarDate || sagStartDate > solEndCarDate))
                    {
                    }
                    else
                    {
                        carDTOs.Add(car);
                    }
                }
                else
                {
                    carDTOs.Add(car);
                }
            }
            return carDTOs;
            
        }

        public async Task<List<CarDTO>> GetCars()
        {
            var dbCar = await context.Cars.ProjectTo<CarDTO>(mapper.ConfigurationProvider).ToListAsync();
            return dbCar;
        }

        public async Task<CarDTO> UpdateCar(CarDTO car)
        {
            var dbCar = await context.Cars.Where(c => c.Id == car.Id).FirstOrDefaultAsync();
            if (dbCar == null)
                throw new Exception("Araba Bulunamadığından Dolayı Güncelleme İşlemi Başarısız");
            mapper.Map(car, dbCar);

            int result=await context.SaveChangesAsync();
            return mapper.Map<CarDTO>(dbCar);
        }
    }
}
