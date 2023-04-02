using EmailService;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace CareManagement.Controllers.SCHDL
{
    public class EmailController : Controller
    {

        private readonly IEmailSender _emailSender;
        public EmailController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
        public IActionResult Index()
        {
            if (TempData["Invoice"] != null)
            {
                var emailContent = "";
                emailContent = (string)TempData["Invoice"];
                var message = new Message(new string[] { "maiphuong.nguyen97@gmail.com" },
                "Invoice CareManagement",
                emailContent);
                _emailSender.SendEmail(message);
            }

            return View();
        }
    }
}
