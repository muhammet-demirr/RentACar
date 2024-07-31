using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RentACar.Application.DTOs;
using RentACar.Domain.Models;
using RentACar.Persistence.Context;
using RentAPartner.Application.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.Services
{
    public class PartnerService : IPartnerService
    {
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly RentACarPsqlDbContext context;
        public PartnerService(IMapper _mapper, IConfiguration _configuration, RentACarPsqlDbContext _context)
        {
            mapper = _mapper;
            configuration = _configuration;
            context = _context;
        }
        public async Task<PartnerDTO> CreatePartner(PartnerDTO Partner)
        {
            var dbPartner = await context.Partners.Where(c => c.Id == Partner.Id).FirstOrDefaultAsync();
            if (dbPartner != null)
                throw new Exception("Bu Servis Zaten Sistemde Kayıtlı");
            dbPartner = mapper.Map<RentACar.Domain.Models.Partner>(Partner);
            dbPartner.CreateDate = DateTime.Now;
            await context.Partners.AddAsync(dbPartner);
            int result = await context.SaveChangesAsync();

            return mapper.Map<PartnerDTO>(dbPartner);
        }

        public async Task<bool> DeletePartnerId(Guid id)
        {
            var dbPartner= await context.Partners.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (dbPartner == null)
                throw new Exception("Seçenek Bulunamadı");
            context.Partners.Remove(dbPartner);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<List<PartnerDTO>> GetPartners()
        {
            var dbPartner = await context.Partners
            .ProjectTo<PartnerDTO>(mapper.ConfigurationProvider).ToListAsync();
            return dbPartner;
        }

        public async Task<PartnerDTO> GetPartnerById(Guid Id)
        {
            var dbPartner = await context.Partners
    .ProjectTo<PartnerDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
            if (dbPartner == null)
                throw new Exception("Seçenek Bulunamadı.");
            return dbPartner;
        }

        public async Task<List<PartnerDTO>> GetPartnersNullToken()
        {
            var dbPartner = await context.Partners
         .ProjectTo<PartnerDTO>(mapper.ConfigurationProvider).ToListAsync();
            return dbPartner;
        }

        public async Task<PartnerDTO> UpdatePartner(PartnerDTO Partner)
        {
            var dbPartner = await context.Partners.Where(c => c.Id == Partner.Id).FirstOrDefaultAsync();
            if (dbPartner == null)
                throw new Exception("Seçenek Bulunamadığından Dolayı Güncelleme İşlemi Başarısız");
            mapper.Map(Partner, dbPartner);

            int result = await context.SaveChangesAsync();
            return mapper.Map<PartnerDTO>(dbPartner);
        }
    }
}
