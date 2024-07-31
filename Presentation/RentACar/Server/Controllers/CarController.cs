using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.DTOs;
using RentACar.Application.DTOs.OtherDTOs;
using RentACar.Application.IServices;
using RentACar.Application.ResponseModels;


namespace RentACar.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CarController : ControllerBase
    {
        private readonly ICarService carService;
        public CarController(ICarService _carService)
        {
            carService = _carService;
        }
        [HttpGet("Cars")]
        [AllowAnonymous]
        public async Task<ServiceResponse<List<CarDTO>>> GetCars()
        {
            return new ServiceResponse<List<CarDTO>>()
            {

                Value = await carService.GetCars()
            };
        }
        [HttpGet("CarRezervations/{startDate}/{endDate}")]
        [AllowAnonymous]
        public async Task<ServiceResponse<List<CarDTO>>> GetCarRezervations(string startDate,string endDate)
        {
            return new ServiceResponse<List<CarDTO>>()
            {

                Value = await carService.GetCarReservations(startDate, endDate)
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<CarDTO>> CreateCar([FromBody] CarDTO Car)
        {
            return new ServiceResponse<CarDTO>()
            {
                Value = await carService.CreateCar(Car)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<CarDTO>> UpdateCar([FromBody] CarDTO Car)
        {
            return new ServiceResponse<CarDTO>()
            {
                Value = await carService.UpdateCar(Car)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteCarById([FromBody] Guid Id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await carService.DeleteCarId(Id)
            };
        }
        [HttpGet("CarById/{Id}")]
        [AllowAnonymous]
        public async Task<ServiceResponse<CarDTO>> GetCarById(Guid Id)
        {
            return new ServiceResponse<CarDTO>()
            {
                Value = await carService.GetCarById(Id)
            };
        }
    }
}
