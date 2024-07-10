using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Attributes;
using BE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    [Route("api/v1/web/payment")]
    [ApiController]
    public class PaymentWebController
    {
        private readonly IPaymentService _payService;
        public PaymentWebController(IPaymentService payService)
        {
            _payService = payService;
        }

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