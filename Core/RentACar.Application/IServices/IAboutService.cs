using RentACar.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.IServices
{
    public interface IAboutService
    {
        public Task<List<AboutDTO>> GetAbouts();
        public Task<AboutDTO> GetAbout();
        public Task<AboutDTO> CreateAbout(AboutDTO About);

        public Task<AboutDTO> UpdateAbout(AboutDTO About);
        public Task<bool> DeleteAboutId(Guid id);
        public Task<AboutDTO> GetAboutById(Guid id);
    }
}
