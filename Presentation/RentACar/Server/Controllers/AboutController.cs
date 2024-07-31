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
    public class AboutController : ControllerBase
    {
        public readonly IAboutService aboutService;

        public AboutController(IAboutService _aboutService)
        {
            aboutService = _aboutService;
        }

        [HttpGet("Abouts")]
        public async Task<ServiceResponse<List<AboutDTO>>> GetAbouts()
        {
            return new ServiceResponse<List<AboutDTO>>()
            {

                Value = await aboutService.GetAbouts()
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<AboutDTO>> CreateAbout([FromBody] AboutDTO About)
        {
            return new ServiceResponse<AboutDTO>()
            {
                Value = await aboutService.CreateAbout(About)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<AboutDTO>> UpdateAbout([FromBody] AboutDTO About)
        {
            return new ServiceResponse<AboutDTO>()
            {
                Value = await aboutService.UpdateAbout(About)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteAboutId([FromBody] Guid Id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await aboutService.DeleteAboutId(Id)
            };
        }
        [HttpGet("AboutBy/{Id}")]
        public async Task<ServiceResponse<AboutDTO>> GetAboutById(Guid Id)
        {
            return new ServiceResponse<AboutDTO>()
            {
                Value = await aboutService.GetAboutById(Id)
            };
        }
        [HttpGet("AboutBys")]
        [AllowAnonymous]
        public async Task<ServiceResponse<AboutDTO>> GetAboutBy()
        {
            return new ServiceResponse<AboutDTO>()
            {
                Value = await aboutService.GetAbout()
            };
        }

    }
}
