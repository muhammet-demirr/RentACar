using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.DTOs;
using RentACar.Application.IServices;
using RentACar.Application.ResponseModels;

namespace RentACar.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CarOptionController : ControllerBase
    {
        private readonly ICarOptionService carOptionService;

        public CarOptionController(ICarOptionService _carOptionService)
        {
            carOptionService = _carOptionService;
        }

        [HttpGet("CarOptions")]
        public async Task<ServiceResponse<List<CarOptionDTO>>> GetCarOptions()
        {
            return new ServiceResponse<List<CarOptionDTO>>()
            {

                Value = await carOptionService.GetCarOptions()
            };
        }
        [HttpGet("CarOptionsNullToken/{CarId}")]
        [AllowAnonymous]
        public async Task<ServiceResponse<List<CarOptionDTO>>> GetCarOptionsNullToken(Guid CarId)
        {
            return new ServiceResponse<List<CarOptionDTO>>()
            {

                Value = await carOptionService.GetCarOptionsNullToken(CarId)
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<CarOptionDTO>> CreateCarOption([FromBody] CarOptionDTO CarOption)
        {
            return new ServiceResponse<CarOptionDTO>()
            {
                Value = await carOptionService.CreateCarOption(CarOption)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<CarOptionDTO>> UpdateCarOption([FromBody] CarOptionDTO CarOption)
        {
            return new ServiceResponse<CarOptionDTO>()
            {
                Value = await carOptionService.UpdateCarOption(CarOption)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteCarOptionId([FromBody] Guid Id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await carOptionService.DeleteCarOptionId(Id)
            };
        }
        [HttpGet("CarOptionById/{Id}")]
        public async Task<ServiceResponse<CarOptionDTO>> GetCarOptionById(Guid Id)
        {
            return new ServiceResponse<CarOptionDTO>()
            {
                Value = await carOptionService.GetCarOptionById(Id)
            };
        }

    }
}
