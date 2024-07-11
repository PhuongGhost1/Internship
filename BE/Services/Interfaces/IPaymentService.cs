using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<int?> GetTotalPricesForSingleMonthAsync();
        Task<double?> GetPercentageChangeForCurrentMonthAsync();
        Task<int?> GetTotalPricesForCurrentWeekAsync();
        Task<double?> GetPercentageChangeForCurrentWeekAsync();
    }
}