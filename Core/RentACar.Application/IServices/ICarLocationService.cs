using RentACar.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarLocation.Application.IServices
{
    public interface ICarLocationService
    {
          public Task<List<CarLocationDTO>> GetCarLocations();
        public Task<CarLocationDTO> CreateCarLocation(CarLocationDTO CarLocation);

        public Task<CarLocationDTO> UpdateCarLocation(CarLocationDTO CarLocation);
        public Task<bool> DeleteCarLocationId(Guid id);
        public Task<CarLocationDTO> GetCarLocationById(Guid id);
    }
}
