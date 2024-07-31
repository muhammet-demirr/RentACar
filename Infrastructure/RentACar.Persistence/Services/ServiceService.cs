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
    public class ServiceService : IServiceService
    {
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly RentACarPsqlDbContext context;
        public ServiceService(IMapper _mapper, IConfiguration _configuration, RentACarPsqlDbContext _context)
        {
            mapper = _mapper;
            configuration = _configuration;
            context = _context;
        }
        public async Task<ServiceDTO> CreateService(ServiceDTO Service)
        {
            var dbService = await context.Services.Where(c => c.Id == Service.Id).FirstOrDefaultAsync();
            if (dbService != null)
                throw new Exception("Bu Hizmet Zaten Sistemde Kayıtlı");
            dbService = mapper.Map<Service>(Service);
            dbService.CreateDate = DateTime.Now;
            await context.Services.AddAsync(dbService);
            int result = await context.SaveChangesAsync();

            return mapper.Map<ServiceDTO>(dbService);

        }

        public async Task<bool> DeleteServiceId(Guid id)
        {
            var dbService = await context.Services.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (dbService == null)
                throw new Exception("Hizmet Bulunamadı");
            context.Services.Remove(dbService);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<ServiceDTO> GetServiceById(Guid Id)
        {
            var dbService = await context.Services.Where(c => c.Id == Id)
                .ProjectTo<ServiceDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
            if (dbService == null)
                throw new Exception("Hizmet Bulunamadı.");
            return dbService;
        }

        public async Task<List<ServiceDTO>> GetServices()
        {
            var dbService = await context.Services.ProjectTo<ServiceDTO>(mapper.ConfigurationProvider).ToListAsync();
            return dbService;
        }

        public async Task<ServiceDTO> UpdateService(ServiceDTO Service)
        {
            var dbService = await context.Services.Where(c => c.Id == Service.Id).FirstOrDefaultAsync();
            if (dbService == null)
                throw new Exception("Hizmet Bulunamadığından Dolayı Güncelleme İşlemi Başarısız");
            mapper.Map(Service, dbService);

            int result = await context.SaveChangesAsync();
            return mapper.Map<ServiceDTO>(dbService);
        }
    }
}
