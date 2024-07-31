using RentACar.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.IServices
{
    public interface ICarOptionService
    {
        public Task<List<CarOptionDTO>> GetCarOptions();
        public Task<CarOptionDTO> CreateCarOption(CarOptionDTO CarOption);
        public Task<CarOptionDTO> UpdateCarOption(CarOptionDTO CarOption);
        public Task<bool> DeleteCarOptionId(Guid id);
        public Task<CarOptionDTO> GetCarOptionById(Guid id);
        public Task<List<CarOptionDTO>> GetCarOptionsNullToken(Guid CarId);

    }
}
