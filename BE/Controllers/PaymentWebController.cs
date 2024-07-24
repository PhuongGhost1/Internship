using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Attributes;
using BE.Helpers;
using BE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    [Route("api/v1/web/payment")]
    [ApiController]
    public class PaymentWebController : ControllerBase
    {
        private readonly IPaymentService _payService;
        public PaymentWebController(IPaymentService payService)
        {
            _payService = payService;
        }

        //-----------------------Payment----------------------------------
        [HttpPost, Route("create-order")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
        {
            var result = await _payService.CreateOrder(request);
            return Ok(result);
        }

        [HttpPost, Route("capture-order/{orderId}")]
        public async Task<IActionResult> CaptureOrder(string orderId)
        {
            var result = await _payService.CaptureOrder(orderId);
            return Ok(result);
        }

        [HttpPost, Route("cancel-order/{orderId}")]
        public async Task<IActionResult> CancelOrder(string orderId)
        {
            try
            {
                var isCanceled = await _payService.CancelOrder(orderId);

                if (!isCanceled)
                {
                    Console.WriteLine("Failed to cancel the order.");
                }

                return Ok("Order canceled successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Internal server error.");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        //-----------------------Payment----------------------------------

        //[CustomAuthorize("Admin")]
        [HttpGet, Route("total-prices-single-month")]
        public async Task<int?> GetTotalPricesForSingleMonthAsync(){
            return await _payService.GetTotalPricesForSingleMonthAsync();
        }

        //[CustomAuthorize("Admin")]
        [HttpGet, Route("get-current-monthly-changes")]
        public async Task<double?> GetPercentageChangeForCurrentMonthAsync(){
            return await _payService.GetPercentageChangeForCurrentMonthAsync();
        }

        //[CustomAuthorize("Admin")]
        [HttpGet, Route("total-prices-single-week")]
        public async Task<double?> GetTotalPricesForCurrentWeekAsync(){
            return await _payService.GetTotalPricesForCurrentWeekAsync();
        }

        //[CustomAuthorize("Admin")]
        [HttpGet, Route("get-current-weekly-changes")]
        public async Task<double?> GetPercentageChangeForCurrentWeekAsync(){
            return await _payService.GetPercentageChangeForCurrentWeekAsync();
        }
    }
}