using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RentACar.Application.DTOs;
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
    public class LocationService : ILocationService
    {
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly RentACarPsqlDbContext context;

        public LocationService(IMapper _mapper, IConfiguration _configuration, RentACarPsqlDbContext _context)
        {
            mapper = _mapper;
            configuration = _configuration;
            context = _context;
        }

        public async Task<LocationDTO> CreateLocation(LocationDTO Location)
        {
            var dbLocation = await context.Locations.Where(c => c.Id == Location.Id).FirstOrDefaultAsync();
            if (dbLocation != null)
                throw new Exception("Bu Lokasyon Zaten Sistemde Kayıtlı");
            dbLocation = mapper.Map<Location>(Location);
            dbLocation.CreateDate = DateTime.Now;
            await context.Locations.AddAsync(dbLocation);
            int result = await context.SaveChangesAsync();

            return mapper.Map<LocationDTO>(dbLocation);

        }

        public async Task<bool> DeleteLocationId(Guid id)
        {
            var dbLocation = await context.Locations.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (dbLocation == null)
                throw new Exception("Lokasyon Bulunamadı");
            context.Locations.Remove(dbLocation);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<LocationDTO> GetLocationById(Guid Id)
        {
            var dbLocation = await context.Locations.Where(c => c.Id == Id)
                .ProjectTo<LocationDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
            if (dbLocation == null)
                throw new Exception("Lokasyon Bulunamadı.");
            return dbLocation;
        }

        public async Task<List<LocationDTO>> GetLocations()
        {
            var dbLocation = await context.Locations.ProjectTo<LocationDTO>(mapper.ConfigurationProvider).ToListAsync();
            return dbLocation;
        }

        public async Task<LocationDTO> UpdateLocation(LocationDTO Location)
        {
            var dbLocation = await context.Locations.Where(c => c.Id == Location.Id).FirstOrDefaultAsync();
            if (dbLocation == null)
                throw new Exception("Lokasyon Bulunamadığından Dolayı Güncelleme İşlemi Başarısız");
            mapper.Map(Location, dbLocation);

            int result = await context.SaveChangesAsync();
            return mapper.Map<LocationDTO>(dbLocation);
        }
    }
}
