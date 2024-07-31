using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.DTOs;
using RentACar.Application.IServices;
using RentACar.Application.ResponseModels;
using RentACar.Persistence.Services;

namespace RentACar.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService serviceService;

        public ServiceController(IServiceService _serviceService)
        {
            serviceService = _serviceService;
        }

        [HttpGet("Services")]
        [AllowAnonymous]
        public async Task<ServiceResponse<List<ServiceDTO>>> GetServices()
        {
            return new ServiceResponse<List<ServiceDTO>>()
            {

                Value = await serviceService.GetServices()
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<ServiceDTO>> CreateService([FromBody] ServiceDTO Service)
        {
            return new ServiceResponse<ServiceDTO>()
            {
                Value = await serviceService.CreateService(Service)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<ServiceDTO>> UpdateService([FromBody] ServiceDTO Service)
        {
            return new ServiceResponse<ServiceDTO>()
            {
                Value = await serviceService.UpdateService(Service)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteServiceId([FromBody] Guid Id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await serviceService.DeleteServiceId(Id)
            };
        }
        [HttpGet("ServiceById/{Id}")]
        public async Task<ServiceResponse<ServiceDTO>> GetServiceById(Guid Id)
        {
            return new ServiceResponse<ServiceDTO>()
            {
                Value = await serviceService.GetServiceById(Id)
            };
        }
    }
}
