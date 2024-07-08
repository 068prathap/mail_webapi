using MailApi.Models;

namespace MailApi.Repository.Mail
{
    public interface IMailService
    {
        bool SendMailMethod(MailData mailData, string otp);
    }
}
