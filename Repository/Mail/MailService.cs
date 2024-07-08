using MailApi.Models;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;
using System.Net.Mail;
using System.Net;
using System.Reflection;
using SmtpClient = System.Net.Mail.SmtpClient;

namespace MailApi.Repository.Mail
{
    public class MailService : IMailService
    {
        public bool SendMailMethod(MailData mailData, string otp)
         {
            try
            {
                MailMessage mailMessage = new MailMessage("prathapselvam6@gmail.com", mailData.EmailToId);

                //mailMessage.Subject = mailData.EmailSubject;
                mailMessage.Subject = "OTP for verification";

                //mailMessage.Body = mailData.EmailBody;
                mailMessage.Body = otp;

                mailMessage.IsBodyHtml = false;

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;

                NetworkCredential nc = new NetworkCredential("prathapselvam6@gmail.com", "ejjv kedj wmgw damv");
                client.Credentials = nc;

                client.Send(mailMessage);

                return true;
            }
            catch (Exception ex)
            {
                // Exception Details
                return false;
            }
        }
    }
}
