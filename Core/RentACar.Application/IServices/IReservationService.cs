using RentACar.Application.DTOs;
using RentACar.Application.DTOs.OtherDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.IServices
{
    public interface IReservationService
    {
        public Task<List<ReservationDTO>> GetReservations();
        public Task<ReservationDTO> CreateReservation(ReservationDTO Reservation);
        public Task<ReservationDTO> UpdateReservation(ReservationDTO Reservation);
        public Task<bool> DeleteReservation(Guid id);
        public Task<ReservationDTO> GetReservationById(Guid id);
        public void SenderEmail(MailSenderDTO mail);
    }
}
