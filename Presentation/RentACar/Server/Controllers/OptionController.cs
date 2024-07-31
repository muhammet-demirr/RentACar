using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RentACar.Application.DTOs;
using RentACar.Application.IServices;
using RentACar.Application.ResponseModels;
using RentACar.Persistence.Services;

namespace RentACar.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OptionController : ControllerBase
    {
        private readonly IOptionService optionService;

        public OptionController(IOptionService _optionService)
        {
            optionService = _optionService;
        }

        [HttpGet("Options")]
        public async Task<ServiceResponse<List<OptionDTO>>> GetOptions()
        {
            return new ServiceResponse<List<OptionDTO>>()
            {

                Value = await optionService.GetOptions()
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<OptionDTO>> CreateOption([FromBody] OptionDTO Option)
        {
            return new ServiceResponse<OptionDTO>()
            {
                Value = await optionService.CreateOption(Option)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<OptionDTO>> UpdateOption([FromBody] OptionDTO Option)
        {
            return new ServiceResponse<OptionDTO>()
            {
                Value = await optionService.UpdateOption(Option)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteOptionId([FromBody] Guid Id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await optionService.DeleteOptionId(Id)
            };
        }
        [HttpGet("OptionBy/{Id}")]
        public async Task<ServiceResponse<OptionDTO>> GetOptionById(Guid Id)
        {
            return new ServiceResponse<OptionDTO>()
            {
                Value = await optionService.GetOptionById(Id)
            };
        }

    }
}
