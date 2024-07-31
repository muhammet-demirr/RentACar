using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.DTOs;
using RentACar.Application.IServices;
using RentACar.Application.ResponseModels;

namespace RentACar.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService _userService)
        {
            userService = _userService;
        }
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ServiceResponse<UserLoginResponseDTO>> Login(UserLoginRequestDTO UserRequest)
        {
            return new ServiceResponse<UserLoginResponseDTO>()
            {
                Value = await userService.Login(UserRequest.Email, UserRequest.Password)
                
            };
        }
        [HttpGet("Users")]
        public async Task<ServiceResponse<List<UserDTO>>> GetUsers()
        {
            return new ServiceResponse<List<UserDTO>>() {

                Value = await userService.GetUsers()
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<UserDTO>>CreateUser([FromBody] UserDTO User)
        {
            return new ServiceResponse<UserDTO>()
            {
                Value = await userService.CreateUser(User)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<UserDTO>> UpdateUser([FromBody] UserDTO User)
        {
            return new ServiceResponse<UserDTO>()
            {
                Value = await userService.UpdateUser(User)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteUserById ([FromBody] Guid Id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await userService.DeleteUserId(Id)
            };
        }
        [HttpGet("UserById/{Id}")]
        public async Task<ServiceResponse<UserDTO>> GetUserById(Guid Id)
        {
            return new ServiceResponse<UserDTO>()
            {
                Value = await userService.GetUserById(Id)
            };
        }
    }
}
