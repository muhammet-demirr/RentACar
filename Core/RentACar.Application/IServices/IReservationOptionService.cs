using RentACar.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.IServices
{
    public interface IReservationOptionService
    {
        public Task<List<ReservationOptionDTO>> GetReservationOptions();
        public Task<ReservationOptionDTO> CreateReservationOption(ReservationOptionDTO ReservationOption);
        public Task<ReservationOptionDTO> UpdateReservationOption(ReservationOptionDTO ReservationOption);
        public Task<bool> DeleteReservationOptionId(Guid id);
        public Task<ReservationOptionDTO> GetReservationOptionById(Guid id);
        public Task<List<ReservationOptionDTO>> GetReservationOptionsById(Guid reservationId);
    }
}
