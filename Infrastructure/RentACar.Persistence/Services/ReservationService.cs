using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using RentACar.Application.DTOs;
using RentACar.Application.DTOs.OtherDTOs;
using RentACar.Application.IServices;
using RentACar.Domain.Models;
using RentACar.Persistence.Context;
using RentACar.Persistence.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace RentACar.Persistence.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly RentACarPsqlDbContext context;
        public ReservationService(IMapper _mapper, IConfiguration _configuration, RentACarPsqlDbContext _context)
        {
            mapper = _mapper;
            configuration = _configuration;
            context = _context;
        }
        public async Task<ReservationDTO> CreateReservation(ReservationDTO Reservation)
        {
            
            var dbReservation = await context.Reservations
                .Include(c => c.Car)
                .Include(c => c.StartLocation)
                .Include(c => c.EndLocation)
                .Where(c => c.Id == Reservation.Id).FirstOrDefaultAsync();
            if (dbReservation != null)
                throw new Exception("Bu Rezervasyon Zaten Sistemde Kayıtlı");
            dbReservation = mapper.Map<Reservation>(Reservation);
            dbReservation.CreateDate = DateTime.Now;
            
            await context.Reservations.AddAsync(dbReservation);
            int result = await context.SaveChangesAsync();
            var car = await context.Cars.Where(c => c.Id == Reservation.CarId).FirstOrDefaultAsync();

            return mapper.Map<ReservationDTO>(dbReservation);

        }

        public async Task<bool> DeleteReservation(Guid id)
        {
            var dbReservation = await context.Reservations.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (dbReservation == null)
                throw new Exception("Rezervasyon Bulunamadı");
            context.Reservations.Remove(dbReservation);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<ReservationDTO> GetReservationById(Guid Id)
        {
            var dbReservation = await context.Reservations.Include(c => c.Car)
                .Include(c => c.StartLocation)
                .Include(c => c.EndLocation).Where(c => c.Id == Id)
                .ProjectTo<ReservationDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
            if (dbReservation == null)
                throw new Exception("Rezervasyon Bulunamadı.");
            return dbReservation;
        }

        public async Task<List<ReservationDTO>> GetReservations()
        {
            var dbReservation = await context.Reservations
                .Include(c => c.Car)
                .Include(c => c.StartLocation)
                .Include(c => c.EndLocation)
                .ProjectTo<ReservationDTO>(mapper.ConfigurationProvider).ToListAsync();
            return dbReservation;
        }

        public void SenderEmail(MailSenderDTO mail)
        {
           MailSender.Gonder(mail);

        }

        public async Task<ReservationDTO> UpdateReservation(ReservationDTO Reservation)
        {
            var dbReservation = await context.Reservations
                .Include(c => c.Car)
                .Include(c => c.StartLocation)
                .Include(c => c.EndLocation)
                .Where(c => c.Id == Reservation.Id).FirstOrDefaultAsync();
            if (dbReservation == null)
                throw new Exception("Rezervasyon Bulunamadığından Dolayı Güncelleme İşlemi Başarısız");
            mapper.Map(Reservation, dbReservation);

            int result = await context.SaveChangesAsync();
            return mapper.Map<ReservationDTO>(dbReservation);
        }
    }
}
