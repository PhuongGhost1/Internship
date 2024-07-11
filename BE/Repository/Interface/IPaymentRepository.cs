using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.Repository.Interface
{
    public interface IPaymentRepository
    {
        Task<int?> GetTotalPricesForSingleMonth();
        Task<double?> GetPercentageChangeForCurrentMonth();
        Task<int?> GetTotalPricesForCurrentWeek();
        Task<int?> GetTotalPricesForPreviousWeek();
        Task<double?> GetPercentageChangeForCurrentWeek();
    }
}