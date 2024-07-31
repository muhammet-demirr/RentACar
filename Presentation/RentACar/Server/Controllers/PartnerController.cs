using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.DTOs;
using RentACar.Application.ResponseModels;
using RentACar.Persistence.Services;
using RentAPartner.Application.IServices;

namespace RentACar.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PartnerController : ControllerBase
    {
        private readonly IPartnerService partnerService;
        public PartnerController(IPartnerService _partnerService)
        {
            partnerService= _partnerService;
        }
        [HttpGet("Partners")]
        public async Task<ServiceResponse<List<PartnerDTO>>> GetPartners()
        {
            return new ServiceResponse<List<PartnerDTO>>()
            {

                Value = await partnerService.GetPartners()
            };
        }
        [HttpGet("PartnersNullToken")]
        [AllowAnonymous]
        public async Task<ServiceResponse<List<PartnerDTO>>> GetPartnersNullToken() 
        { 
            return new ServiceResponse<List<PartnerDTO>>()
            {

                Value = await partnerService.GetPartnersNullToken()
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<PartnerDTO>> CreatePartner([FromBody] PartnerDTO Partner)
        {
            return new ServiceResponse<PartnerDTO>()
            {
                Value = await partnerService.CreatePartner(Partner)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<PartnerDTO>> UpdatePartner([FromBody] PartnerDTO Partner)
        {
            return new ServiceResponse<PartnerDTO>()
            {
                Value = await partnerService.UpdatePartner(Partner)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteCarById([FromBody] Guid Id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await partnerService.DeletePartnerId(Id)
            };
        }
        [HttpGet("PartnerById/{Id}")]
        public async Task<ServiceResponse<PartnerDTO>> GetPartnerById(Guid Id)
        {
            return new ServiceResponse<PartnerDTO>()
            {
                Value = await partnerService.GetPartnerById(Id)
            };
        }
    }
}
