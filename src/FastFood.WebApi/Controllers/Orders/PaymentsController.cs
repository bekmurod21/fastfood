using FastFood.Domain.Enums;
using FastFood.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using FastFood.Domain.Configurations;
using FastFood.Service.DTOs.Attachment;
using FastFood.Service.DTOs.PaymentDto;
using FastFood.Service.Interfaces.Orders;
using FastFood.WebApi.Extensions;

namespace FastFood.WebApi.Controllers.Orders
{
    public class PaymentsController : RestfulSense
    {
        private readonly IPaymentService service;

        public PaymentsController(IPaymentService service)
        {
            this.service = service;
        }
        [HttpPost]
        public async ValueTask<IActionResult> PostAsyn([FromForm] SingleFile file, [FromForm] PaymentForCreationDto dto) =>
           Ok(new Response
           {
               Code = 200,
               Message = "Seccess",
               Data = await this.service.AddAsync(dto, await file.File.ToAttachmentAsync())
           });
        [HttpPut("{id}")]
        public async ValueTask<IActionResult> PutAsync(long id, PaymentForCreationDto dto) =>
            Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await this.service.ModifyAsync(id, dto)
            });
        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> DeleteAsync(long id) =>
            Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await this.service.RemoveAsync(id)
            });
        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetById(long id) =>
            Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await this.service.RetrieveAsync(id)
            });
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync([FromQuery] PaginationParams @params) =>
            Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await this.service.RetrieveAllAsync(@params)
            });
        [HttpPut]
        public async ValueTask<IActionResult> ChangeStatusAsync(long id, PaymentStatus status) =>
            Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await this.service.ChangeStatusAsync(id, status)
            });
    } 
}
