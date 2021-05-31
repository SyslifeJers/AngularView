using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace AngularView.Controllers
{
    public class Herramientas
    {
        public static void Correo(string EmailDestino,string asunto,string Body)
        {
            string EmailOrigen = "ventas@aldacomp.com";
            string pass = "Temporal12@";
            MailMessage mailMessage = new MailMessage(EmailOrigen, EmailDestino, asunto, Body);
            mailMessage.IsBodyHtml = true;
            
            SmtpClient smtpClient = new SmtpClient("smtp.dreamhost.com");
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Port = 587;
            smtpClient.Credentials = new System.Net.NetworkCredential(EmailOrigen, pass);
            smtpClient.Send(mailMessage);
            smtpClient.Dispose();

        }

    }
}
