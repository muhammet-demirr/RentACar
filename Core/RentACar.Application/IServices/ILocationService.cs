using RentACar.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.IServices
{
    public interface ILocationService
    {
        public Task<List<LocationDTO>> GetLocations();
        public Task<LocationDTO> CreateLocation(LocationDTO Location);
        public Task<LocationDTO> UpdateLocation(LocationDTO Location);
        public Task<bool> DeleteLocationId(Guid id);
        public Task<LocationDTO> GetLocationById(Guid id);
    }
}
