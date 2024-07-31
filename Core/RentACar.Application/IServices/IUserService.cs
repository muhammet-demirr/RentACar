using RentACar.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.IServices
{
    public interface IUserService
    {
        public Task<List<UserDTO>> GetUsers();
        public Task<UserDTO> CreateUser(UserDTO User);
        public Task<UserDTO> UpdateUser(UserDTO User);
        public Task<bool> DeleteUserId(Guid id);
        public Task<UserDTO> GetUserById(Guid id);
        public Task<UserLoginResponseDTO> Login(string Email, string Password);
    }
}
