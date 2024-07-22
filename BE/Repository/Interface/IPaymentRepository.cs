using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Models;

namespace BE.Repository.Interface
{
    public interface IPaymentRepository
    {
        Task<int?> GetTotalPricesForSingleMonth();
        Task<double?> GetPercentageChangeForCurrentMonth();
        Task<int?> GetTotalPricesForCurrentWeek();
        Task<int?> GetTotalPricesForPreviousWeek();
        Task<double?> GetPercentageChangeForCurrentWeek();
        Task<Payment> CreatePaymentPayingCourse(string userId, float? totalMoney);
        Task CreatePaymentCourse(Payment payment, CartCourse cartCourse);
        Task CreatePaymentAffiliate(CartCourse cartCourse, Affiliate affiliate);
    }
}