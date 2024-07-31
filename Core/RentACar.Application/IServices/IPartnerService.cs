using RentACar.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAPartner.Application.IServices
{
    public interface IPartnerService
    {
        public Task<List<PartnerDTO>> GetPartners();
        public Task<PartnerDTO> CreatePartner(PartnerDTO Partner);
        public Task<PartnerDTO> UpdatePartner(PartnerDTO Partner);
        public Task<bool> DeletePartnerId(Guid id);
        public Task<PartnerDTO> GetPartnerById(Guid Id);
        public Task<List<PartnerDTO>> GetPartnersNullToken();
    }
}
