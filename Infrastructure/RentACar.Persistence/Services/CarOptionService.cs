using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RentACar.Application.DTOs;
using RentACar.Application.IServices;
using RentACar.Persistence.Context;
using RentACarLocation.Application.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.Services
{
    public class CarOptionService : ICarOptionService
    {

        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly RentACarPsqlDbContext context;
        public CarOptionService(IMapper _mapper, IConfiguration _configuration, RentACarPsqlDbContext _context)
        {
            mapper = _mapper;
            configuration = _configuration;
            context = _context;
        }
        public async Task<CarOptionDTO> CreateCarOption(CarOptionDTO CarOption)
        {
            var dbCarOption = await context.CarOptions.Include(c => c.Car)
                .Include(c => c.Option).Where(c => c.Id == CarOption.Id).FirstOrDefaultAsync();
            if (dbCarOption != null)
                throw new Exception("Bu Servis Zaten Sistemde Kayıtlı");
            dbCarOption = mapper.Map<RentACar.Domain.Models.CarOption>(CarOption);
            dbCarOption.CreateDate = DateTime.Now;
            await context.CarOptions.AddAsync(dbCarOption);
            int result = await context.SaveChangesAsync();

            return mapper.Map<CarOptionDTO>(dbCarOption);

        }

        public async Task<bool> DeleteCarOptionId(Guid id)
        {
            var dbCarOption = await context.CarOptions.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (dbCarOption == null)
                throw new Exception("Seçenek Bulunamadı");
            context.CarOptions.Remove(dbCarOption);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<CarOptionDTO> GetCarOptionById(Guid Id)
        {
            var dbCarOption = await context.CarOptions.Include(c => c.Car).Include(c => c.Option).Where(c => c.Id == Id)
                .ProjectTo<CarOptionDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
            if (dbCarOption == null)
                throw new Exception("Seçenek Bulunamadı.");
            return dbCarOption;
        }

        public async Task<List<CarOptionDTO>> GetCarOptions()
        {
            var dbCarOption = await context.CarOptions.Include(c => c.Car).Include(c => c.Option)
                .ProjectTo<CarOptionDTO>(mapper.ConfigurationProvider).ToListAsync();
            return dbCarOption;
        }

        public async Task<List<CarOptionDTO>> GetCarOptionsNullToken(Guid CarId)
        {
            var db =await context.CarOptions
                .Include(c => c.Car)
                .Include(c => c.Option)
                .Where(c=>c.CarId==CarId).ProjectTo<CarOptionDTO>(mapper.ConfigurationProvider).ToListAsync();
            return db;
        }

        public async Task<CarOptionDTO> UpdateCarOption(CarOptionDTO CarOption)
        {
            var dbCarOption = await context.CarOptions.Include(c => c.Car).Include(c => c.Option).Where(c => c.Id == CarOption.Id).FirstOrDefaultAsync();
            if (dbCarOption == null)
                throw new Exception("Seçenek Bulunamadığından Dolayı Güncelleme İşlemi Başarısız");
            mapper.Map(CarOption, dbCarOption);

            int result = await context.SaveChangesAsync();
            return mapper.Map<CarOptionDTO>(dbCarOption);
        }
    }
}
