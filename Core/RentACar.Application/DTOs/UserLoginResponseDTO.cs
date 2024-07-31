using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.DTOs
{
    public class UserLoginResponseDTO
    {
        public string ApiToken { get; set; }
        public UserDTO User { get; set; }
    }
}
