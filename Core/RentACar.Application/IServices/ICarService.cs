using RentACar.Application.DTOs;
using RentACar.Application.DTOs.OtherDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.IServices
{
    public interface ICarService
    {
        public Task<List<CarDTO>> GetCars();
        public Task<CarDTO> CreateCar(CarDTO Car);
        public Task<CarDTO> UpdateCar(CarDTO car);
        public Task<bool> DeleteCarId(Guid id);
        public Task<CarDTO> GetCarById(Guid Id);
        public Task<List<CarDTO>> GetCarReservations(string startDate,string endDate);

    }
}
