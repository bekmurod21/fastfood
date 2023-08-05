using FastFood.Service.Interfaces.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace FastFood.WebApi.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailsController : ControllerBase
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
