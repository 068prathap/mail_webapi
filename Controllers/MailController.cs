using MailApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MailApi.Repository.Mail;
using static System.Net.WebRequestMethods;

namespace MailApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailService _mailService;
        //injecting the IMailService into the constructor
        public MailController(IMailService _MailService)
        {
            _mailService = _MailService;
        }

        [HttpPost]
        [Route("SendMail")]
        public IActionResult SendMail(MailData mailData)
        {
            Random rnd = new Random();
            string otp = Convert.ToString(rnd.Next(1000, 9999));

            bool result = _mailService.SendMailMethod(mailData, otp);
            if (result)
            {
                return Ok(otp);
            }
            else
            {
                return StatusCode(500, "something wrong in server");
            }
        }
    }
}