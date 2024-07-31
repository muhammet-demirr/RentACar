using Microsoft.AspNetCore.SignalR;
using RentACar.Application.DTOs;
using RentACar.Application.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.Hubs
{
    public class SignalRHub:Hub
    {
        public async Task SendMessage()
        {
           await Clients.All.SendAsync("Receivemessage");
        }
    }
}
