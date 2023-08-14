using FastFood.Service.Interfaces.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace FastFood.WebApi.Controllers.Users
{
    public class EmailsController : RestfulSense
    {
        private readonly IEmailService service;

        public EmailsController(IEmailService service)
        {
            this.service = service;
        }
        [HttpPost]
        public async Task<IActionResult> SendAsync(string to,string subject,string message)
        {   
            await this.service.SendEmailAsync(to,subject,message);
            return Ok();
        }
    }
}
