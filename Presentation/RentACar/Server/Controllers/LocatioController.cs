using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.DTOs;
using RentACar.Application.IServices;
using RentACar.Application.ResponseModels;

namespace RentACar.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LocatioController : ControllerBase
    {
        private readonly ILocationService locationService;
        public LocatioController(ILocationService _locationService)
        {
            locationService = _locationService;
        }
        [HttpGet("Locations")]
        [AllowAnonymous]
        public async Task<ServiceResponse<List<LocationDTO>>> GetLocations()
        {
            return new ServiceResponse<List<LocationDTO>>()
            {

                Value = await locationService.GetLocations()
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<LocationDTO>> CreateLocation([FromBody] LocationDTO Location)
        {
            return new ServiceResponse<LocationDTO>()
            {
                Value = await locationService.CreateLocation(Location)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<LocationDTO>> UpdateLocation([FromBody] LocationDTO Location)
        {
            return new ServiceResponse<LocationDTO>()
            {
                Value = await locationService.UpdateLocation(Location)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteLocationId([FromBody] Guid Id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await locationService.DeleteLocationId(Id)
            };
        }
        [HttpGet("LocationById/{Id}")]
        public async Task<ServiceResponse<LocationDTO>> GetLocationById(Guid Id)
        {
            return new ServiceResponse<LocationDTO>()
            {
                Value = await locationService.GetLocationById(Id)
            };
        }
    }
}
