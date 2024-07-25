using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Helpers;

namespace BE.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<int?> GetTotalPricesForSingleMonthAsync();
        Task<double?> GetPercentageChangeForCurrentMonthAsync();
        Task<int?> GetTotalPricesForCurrentWeekAsync();
        Task<double?> GetPercentageChangeForCurrentWeekAsync();
        Task<CreateOrderResponse> CreateOrder(CreateOrderRequest request);
        Task<CaptureOrderResponse> CaptureOrder(string orderId);
        Task<bool> CancelOrder(string orderId);
    }
}