using FastFood.Domain.Configurations;
using FastFood.Domain.Enums;
using FastFood.Service.Interfaces.Orders;
using FastFood.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FastFood.WebApi.Controllers.Feedbacks
{
    public class FeedbackAdminController : RestfulSense
    {
        private readonly IFeedbackAdminService service;

        public FeedbackAdminController(IFeedbackAdminService service)
        {
            this.service = service;
        }
        [HttpPatch("{id}")]
        public async ValueTask<IActionResult> MarkAsReadAsync([FromRoute] long id) =>
         Ok(new Response()
         {
           Code = 200,
           Message = "OK",
           Data = await this.service.MarkAsReadAsync(id)
         });
        [HttpGet("feedbacks")]
        public async ValueTask<IActionResult> GetAllByStatusAsync([FromQuery] PaginationParams @params,
           [FromQuery] FeedbackStatus? status = null)
        {
            return Ok(new Response()
            {
                Code = 200,
                Message = "OK",
                Data = await this.service.RetriveAllByStatusAsync(@params, status)
            });
        }
        [HttpGet("client-id")]
        public async ValueTask<IActionResult> GetAllByClientIdAsync(long clientId)
        {
            return Ok(new Response()
            {
                Code = 200,
                Message = "OK",
                Data = await this.service.RetrieveAllByClientIdAsync(clientId)
            });
        }

    }
}
