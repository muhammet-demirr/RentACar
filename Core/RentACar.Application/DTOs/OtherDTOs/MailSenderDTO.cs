using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.DTOs.OtherDTOs
{
    public class MailSenderDTO
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public string SenderMail { get; set; }
    }
}
