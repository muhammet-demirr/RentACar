using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.DTOs.OtherDTOs;
using RentACar.Application.CustomExceptions;
using MimeKit;
using MailKit.Net.Smtp;

namespace RentACar.Persistence.Extensions
{
    public static class MailSender
    {
        public static  void Gonder(MailSenderDTO mailSender)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("info@eaglerentacar.com.tr"));
                email.To.Add(MailboxAddress.Parse(mailSender.SenderMail));
                email.To.Add(MailboxAddress.Parse("eagledenizcilik@outlook.com.tr"));
                email.Subject = mailSender.Subject;
                email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = mailSender.Content };
                using var smtp = new SmtpClient();
                smtp.SslProtocols = System.Security.Authentication.SslProtocols.Tls;
                smtp.CheckCertificateRevocation = false;
                smtp.Connect("mail.eaglerentacar.com.tr", 587, MailKit.Security.SecureSocketOptions.None);

                smtp.Authenticate("info@eaglerentacar.com.tr", "Cib_17421");

                smtp.Send(email);
                smtp.Disconnect(true);

            }
            catch (ApiException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}
