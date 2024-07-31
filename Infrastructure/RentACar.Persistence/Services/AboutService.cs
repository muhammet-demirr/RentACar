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
    public class AboutService : IAboutService
    {
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly RentACarPsqlDbContext context;

        public AboutService(IMapper _mapper, IConfiguration _configuration, RentACarPsqlDbContext _context)
        {
            mapper = _mapper;
            configuration = _configuration;
            context = _context;
        }

        public async Task<AboutDTO> CreateAbout(AboutDTO About)
        {
            var dbAbout = await context.Abouts.Where(c => c.Id == About.Id).FirstOrDefaultAsync();
            if (dbAbout != null)
                throw new Exception("Bu Hakkımızda Kısmı Zaten Sistemde Kayıtlı");
            dbAbout = mapper.Map<About>(About);
            dbAbout.CreateDate = DateTime.Now;
            await context.Abouts.AddAsync(dbAbout);
            int result = await context.SaveChangesAsync();

            return mapper.Map<AboutDTO>(dbAbout);

        }

        public async Task<bool> DeleteAboutId(Guid id)
        {
            var dbAbout = await context.Abouts.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (dbAbout == null)
                throw new Exception("Hakkımızda Kısmı Bulunamadı");
            context.Abouts.Remove(dbAbout);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<AboutDTO> GetAbout()
        {
           var dbAbout = await context.Abouts.ProjectTo<AboutDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync();

            return dbAbout;
        }

        public async Task<AboutDTO> GetAboutById(Guid Id)
        {
            var dbAbout = await context.Abouts.Where(c => c.Id == Id)
                .ProjectTo<AboutDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
            if (dbAbout == null)
                throw new Exception("Hakkımızda Kısmı Bulunamadı.");
            return dbAbout;
        }

        public async Task<List<AboutDTO>> GetAbouts()
        {
            var dbAbout = await context.Abouts.ProjectTo<AboutDTO>(mapper.ConfigurationProvider).ToListAsync();
            return dbAbout;
        }

        public async Task<AboutDTO> UpdateAbout(AboutDTO About)
        {
            var dbAbout = await context.Abouts.Where(c => c.Id == About.Id).FirstOrDefaultAsync();
            if (dbAbout == null)
                throw new Exception("Hakkımızda kısmı Bulunamadığından Dolayı Güncelleme İşlemi Başarısız");
            mapper.Map(About, dbAbout);

            int result = await context.SaveChangesAsync();
            return mapper.Map<AboutDTO>(dbAbout);
        }

    }
}
