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
    public class ReservationOptionService : IReservationOptionService
    {

        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly RentACarPsqlDbContext context;
        public ReservationOptionService(IMapper _mapper, IConfiguration _configuration, RentACarPsqlDbContext _context)
        {
            mapper = _mapper;
            configuration = _configuration;
            context = _context;
        }
        public async Task<ReservationOptionDTO> CreateReservationOption(ReservationOptionDTO ReservationOption)
        {
            try
            {
                var dbReservationOption = await context.ReservationOptions.Include(c => c.Option)
    .Include(c => c.Reservation).Where(c => c.Id == ReservationOption.Id).FirstOrDefaultAsync();
                if (dbReservationOption != null)
                    throw new Exception("Bu Rezervasyon Seçeneği Zaten Sistemde Kayıtlı");
                dbReservationOption = mapper.Map<ReservationOption>(ReservationOption);
                dbReservationOption.CreateDate = DateTime.Now;
                await context.ReservationOptions.AddAsync(dbReservationOption);
                int result = await context.SaveChangesAsync();

                return mapper.Map<ReservationOptionDTO>(dbReservationOption);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.InnerException.Message);
            }

        }

        public async Task<bool> DeleteReservationOptionId(Guid id)
        {
            var dbReservationOption = await context.ReservationOptions.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (dbReservationOption == null)
                throw new Exception("Rezervasyon Seçeneği Bulunamadı");
            context.ReservationOptions.Remove(dbReservationOption);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public Task<ReservationOptionDTO> GetCReservationOptionById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ReservationOptionDTO> GetReservationOptionById(Guid Id)
        {
            var dbReservationOption = await context.ReservationOptions.Include(c => c.Option).Include(c => c.Reservation).Where(c => c.Id == Id)
                .ProjectTo<ReservationOptionDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
            if (dbReservationOption == null)
                throw new Exception("Rezervasyon seçeneği Bulunamadı.");
            return dbReservationOption;
        }

        public async Task<List<ReservationOptionDTO>> GetReservationOptions()
        {
            var dbReservationOption = await context.ReservationOptions.Include(c => c.Option)
                .Include(c => c.Reservation).ProjectTo<ReservationOptionDTO>(mapper.ConfigurationProvider).ToListAsync();
            return dbReservationOption;
        }

        public async Task<List<ReservationOptionDTO>> GetReservationOptionsById(Guid reservationId)
        {
            var dbReservationOption = await context.ReservationOptions.Include(c => c.Option)
                .Include(c => c.Reservation).ProjectTo<ReservationOptionDTO>(mapper.ConfigurationProvider).Where(c => c.ReservationId == reservationId).ToListAsync();
            return dbReservationOption;
        }

        public async Task<ReservationOptionDTO> UpdateReservationOption(ReservationOptionDTO ReservationOption)
        {
            var dbReservationOption = await context.ReservationOptions.Include(c => c.Option)
                .Include(c => c.Reservation).Where(c => c.Id == ReservationOption.Id).FirstOrDefaultAsync();
            if (dbReservationOption == null)
                throw new Exception("Rezervasyon seçeneği Bulunamadığından Dolayı Güncelleme İşlemi Başarısız");
            mapper.Map(ReservationOption, dbReservationOption);

            int result = await context.SaveChangesAsync();
            return mapper.Map<ReservationOptionDTO>(dbReservationOption);
        }
    }
}
