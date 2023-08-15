using FastFood.Service.DTOs.Attachment;
using FastFood.Service.DTOs.Feedbacks;
using FastFood.Service.Interfaces.Orders;
using FastFood.WebApi.Extensions;
using FastFood.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FastFood.WebApi.Controllers.Feedbacks
{
    public class FeedbacksController : RestfulSense
    {
        private readonly IFeedbackService feedbackService;

        public FeedbacksController(IFeedbackService feedbackService)
        {
            this.feedbackService = feedbackService;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromForm] FeedbackForCreationDto dto, [FromForm] List<IFormFile> files)
        {
            var attachments = new List<AttachmentForCreationDto>();
            foreach (var file in files)
            {
                attachments.Add(await file.ToAttachmentAsync());
            }
           return Ok(new Response()
            {
                Code = 200,
                Message = "Success",
                Data = await this.feedbackService.AddAsync(dto,attachments)
            });
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(long id) =>
            Ok(new Response()
            {
                Code = 200,
                Message = "Success",
                Data = await this.feedbackService.RemoveAsync(id)
            });
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id) =>
            Ok(new Response()
            {
                Code = 200,
                Message = "Success",
                Data = await this.feedbackService.RetrieveAsync(id)
            });
    }
}
