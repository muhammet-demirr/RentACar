using RentACar.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.IServices
{
    public interface IOptionService
    {
        public Task<List<OptionDTO>> GetOptions();
        public Task<OptionDTO> CreateOption(OptionDTO Option);
        public Task<OptionDTO> UpdateOption(OptionDTO Option);
        public Task<bool> DeleteOptionId(Guid id);
        public Task<OptionDTO> GetOptionById(Guid Id);
       

    }
}
