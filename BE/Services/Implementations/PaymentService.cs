using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Repository.Interface;
using BE.Services.Interfaces;

namespace BE.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _payRepo;
        public PaymentService(IPaymentRepository payRepo)
        {
            _payRepo = payRepo;
        }

        public async Task<double?> GetPercentageChangeForCurrentMonthAsync()
        {
            return await _payRepo.GetPercentageChangeForCurrentMonth();
        }

        public async Task<double?> GetPercentageChangeForCurrentWeekAsync()
        {
            return await _payRepo.GetPercentageChangeForCurrentWeek();
        }

        public async Task<int?> GetTotalPricesForCurrentWeekAsync()
        {
            return await _payRepo.GetTotalPricesForCurrentWeek();
        }

        public async Task<int?> GetTotalPricesForSingleMonthAsync()
        {
            return await _payRepo.GetTotalPricesForSingleMonth();
        }
    }
}