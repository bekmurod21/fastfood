﻿using FastFood.Service.Interfaces.Orders;
using FastFood.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FastFood.WebApi.Controllers.Orders
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderActionsController : ControllerBase
    {
        private readonly IOrderActionService orderActionService;
        public OrderActionsController(IOrderActionService orderActionService)
        {
            this.orderActionService = orderActionService;
        }

        [HttpPost("pending")]
        public async Task<IActionResult> StartPendingAsync(long orderId)
            => Ok(new Response
            {
                Code = 200,
                Message = "OK",
                Data = await orderActionService.StartPendingAsync(orderId)
            });


        [HttpPost("preparing")]
        public async Task<IActionResult> StartPreparingAsync(long orderId)
            => Ok(new Response
            {
                Code = 200,
                Message = "OK",
                Data = await orderActionService.StartPreparingAsync(orderId)
            });


        [HttpPost("start")]
        public async Task<IActionResult> StartShippingAsync(long orderId)
            => Ok(new Response
            {
                Code = 200,
                Message = "OK",
                Data = await orderActionService.StartShippingAsync(orderId)
            });


        [HttpPost("finished")]
        public async Task<IActionResult> FinishDeliveryAsync(long orderId)
            => Ok(new Response
            {
                Code = 200,
                Message = "OK",
                Data = await orderActionService.FinishDeliveryAsync(orderId)
            });



        [HttpPost("cancelled")]
        public async Task<IActionResult> CancelledAsync(long orderId)
            => Ok(new Response
            {
                Code = 200,
                Message = "OK",
                Data = await orderActionService.CancelledAsync(orderId)
            });
    }
}
