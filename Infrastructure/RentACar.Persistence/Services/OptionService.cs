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
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.Services
{
    public class OptionService : IOptionService
    {

        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly RentACarPsqlDbContext context;

        public OptionService(IMapper _mapper, IConfiguration _configuration, RentACarPsqlDbContext _context)
        {
            mapper = _mapper;
            configuration = _configuration;
            context = _context;
        }
        public async Task<OptionDTO> CreateOption(OptionDTO Option)
        {
            var dbOption = await context.Options.Where(c => c.Id == Option.Id).FirstOrDefaultAsync();
            if (dbOption != null)
                throw new Exception("Bu seçenek Zaten Sistemde Kayıtlı");
            dbOption = mapper.Map<Option>(Option);
            dbOption.CreateDate = DateTime.Now;
            await context.Options.AddAsync(dbOption);
            int result = await context.SaveChangesAsync();

            return mapper.Map<OptionDTO>(dbOption);

        }

        public async Task<bool> DeleteOptionId(Guid id)
        {
           var dbOption = await context.Options.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (dbOption == null)
                throw new Exception("Seçenek Bulunamadı");
            context.Options.Remove(dbOption);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<OptionDTO> GetOptionById(Guid Id)
        {
            var dbOption = await context.Options.Where(c => c.Id == Id)
                .ProjectTo<OptionDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
            if (dbOption == null)
                throw new Exception("Seçenek Bulunamadı.");
            return dbOption;
        }

        public async Task<List<OptionDTO>> GetOptions()
        {
            var dbOption = await context.Options.ProjectTo<OptionDTO>(mapper.ConfigurationProvider).ToListAsync();
            return dbOption;
        }

        public async Task<OptionDTO> UpdateOption(OptionDTO Option)
        {
            var dbOption = await context.Options.Where(c => c.Id == Option.Id).FirstOrDefaultAsync();
            if (dbOption == null)
                throw new Exception("Seçenek Bulunamadığından Dolayı Güncelleme İşlemi Başarısız");
            mapper.Map(Option, dbOption);

            int result = await context.SaveChangesAsync();
            return mapper.Map<OptionDTO>(dbOption);
        }
    }
}
