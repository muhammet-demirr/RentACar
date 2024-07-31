using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RentACar.Application.DTOs;
using RentACar.Domain.Models;
using RentACar.Persistence.Context;
using RentACarLocation.Application.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.Services
{

    public class CarLocationService:ICarLocationService
    {
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly RentACarPsqlDbContext context;
        public CarLocationService(IMapper _mapper, IConfiguration _configuration, RentACarPsqlDbContext _context)
        {
            mapper = _mapper;
            configuration = _configuration;
            context = _context;
        }
        public async Task<CarLocationDTO> CreateCarLocation(CarLocationDTO CarLocation)
        {
            var dbCarLocation = await context.CarLocations.Include(c=>c.Car)
                .Include(c=>c.Location).Where(c => c.Id == CarLocation.Id).FirstOrDefaultAsync();
            if (dbCarLocation != null)
                throw new Exception("Bu konum Zaten Sistemde Kayıtlı");
            dbCarLocation = mapper.Map<CarLocation>(CarLocation);
            dbCarLocation.CreateDate = DateTime.Now;
            await context.CarLocations.AddAsync(dbCarLocation);
            int result = await context.SaveChangesAsync();

            return mapper.Map<CarLocationDTO>(dbCarLocation);

        }

        public async Task<bool> DeleteCarLocationId(Guid id)
        {
            var dbCarLocation = await context.CarLocations.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (dbCarLocation == null)
                throw new Exception("Lokasyon Bulunamadı");
            context.CarLocations.Remove(dbCarLocation);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<CarLocationDTO> GetCarLocationById(Guid Id)
        {
            var dbCarLocation = await context.CarLocations.Include(c=>c.Car).Include(c=>c.Location).Where(c => c.Id == Id)
                .ProjectTo<CarLocationDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
            if (dbCarLocation == null)
                throw new Exception("Lokasyon Bulunamadı.");
            return dbCarLocation;
        }

        public async Task<List<CarLocationDTO>> GetCarLocations()
        {
            var dbCarLocation = await context.CarLocations.Include(c=>c.Car).Include(c=>c.Location).ProjectTo<CarLocationDTO>(mapper.ConfigurationProvider).ToListAsync();
            return dbCarLocation;
        }

        public async Task<CarLocationDTO> UpdateCarLocation(CarLocationDTO car)
        {
            var dbCarLocation = await context.CarLocations.Include(c=>c.Car).Include(c=>c.Location).Where(c => c.Id == car.Id).FirstOrDefaultAsync();
            if (dbCarLocation == null)
                throw new Exception("Lokasyon Bulunamadığından Dolayı Güncelleme İşlemi Başarısız");
            mapper.Map(car, dbCarLocation);

            int result = await context.SaveChangesAsync();
            return mapper.Map<CarLocationDTO>(dbCarLocation);
        }
    }
}
