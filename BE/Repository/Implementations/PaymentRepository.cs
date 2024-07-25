using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Models;
using BE.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using static BE.Utils.Utils;

namespace BE.Repository.Implementations
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly CourseOnlContext _context;
        public PaymentRepository(CourseOnlContext context)
        {
            _context = context;
        }
        public async Task<bool> UpdateStatusPayment(string paymentId)
        {
            var payment = await _context.Payments.FirstOrDefaultAsync(payment => payment.Id == paymentId);

            if(payment == null) return false;

            payment.Status = 1;

            _context.Payments.Update(payment);
            await _context.SaveChangesAsync();
            
            return true;
        }
        
        public async Task<Payment?> GetPaymentInfoFromPaymentByPaymentCode(string paymentCode)
        {
            return await _context.Payments.FirstOrDefaultAsync(pay => pay.PaymendCode == paymentCode);
        }

        public async Task AddPayment(Payment payment)
        {
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePaymentInfo(Payment payment)
        {
            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();
        }

        public async Task<int?> GetTotalPricesForSingleMonth()
        {
            var currentDate = DateTime.UtcNow;
            var startOfMonth = new DateTime(currentDate.Year, currentDate.Month, 1);
            var endOfMonth = startOfMonth.AddMonths(1).AddTicks(-1);

            var total = await _context.Payments
                                    .Where(pay => pay.CreateDate >= startOfMonth && pay.CreateDate <= endOfMonth)
                                    .Select(pay => pay.Total)
                                    .SumAsync();
            return (int)total;
        }

        public async Task<double?> GetPercentageChangeForCurrentMonth()
        {
            var currentDate = DateTime.UtcNow;

            var startOfCurrentMonth = new DateTime(currentDate.Year, currentDate.Month, 1);
            var endOfCurrentMonth = startOfCurrentMonth.AddMonths(1).AddTicks(-1);

            var startOfPreviousMonth = startOfCurrentMonth.AddMonths(-1);
            var endOfPreviousMonth = startOfCurrentMonth.AddTicks(-1);

            var currentMonthTotal = await _context.Payments
                                                .Where(pay => pay.CreateDate >= startOfCurrentMonth && pay.CreateDate <= endOfCurrentMonth)
                                                .Select(pay => pay.Total)
                                                .SumAsync();

            var previousMonthTotal = await _context.Payments
                                                .Where(pay => pay.CreateDate >= startOfPreviousMonth && pay.CreateDate <= endOfPreviousMonth)
                                                .Select(pay => pay.Total)
                                                .SumAsync();

            if (previousMonthTotal == 0) return currentMonthTotal > 0 ? 100 : 0;

            var percentageChange = ((currentMonthTotal.Value - previousMonthTotal.Value) / (double)previousMonthTotal.Value) * 100;

            var formattedPercentageChange = Math.Round(percentageChange, 2);
            return formattedPercentageChange;
        }

        public async Task<int?> GetTotalPricesForCurrentWeek()
        {
            var currentDate = DateTime.UtcNow;

            var startOfWeek = currentDate.Date.AddDays(-(int)currentDate.DayOfWeek);
            var endOfWeek = startOfWeek.AddDays(7).AddTicks(-1);

            var total = await _context.Payments
                                    .Where(pay => pay.CreateDate >= startOfWeek && pay.CreateDate <= endOfWeek)
                                    .Select(pay => pay.Total)
                                    .SumAsync();
            return (int)total;
        }

        public async Task<int?> GetTotalPricesForPreviousWeek()
        {
            var currentDate = DateTime.UtcNow;

            var startOfCurrentWeek = currentDate.Date.AddDays(-(int)currentDate.DayOfWeek);
            var startOfPreviousWeek = startOfCurrentWeek.AddDays(-7);
            var endOfPreviousWeek = startOfPreviousWeek.AddDays(7).AddTicks(-1);

            var total = await _context.Payments
                                    .Where(pay => pay.CreateDate >= startOfPreviousWeek && pay.CreateDate <= endOfPreviousWeek)
                                    .Select(pay => pay.Total)
                                    .SumAsync();
            return (int)total;
        }

        public async Task<double?> GetPercentageChangeForCurrentWeek()
        {
            var currentWeekTotal = await GetTotalPricesForCurrentWeek();
            var previousWeekTotal = await GetTotalPricesForPreviousWeek();

            if (previousWeekTotal == 0) return currentWeekTotal > 0 ? 100 : 0;

            if (currentWeekTotal == null || previousWeekTotal == null) return 0;

            var percentageChange = ((currentWeekTotal.Value - previousWeekTotal.Value) / (double)previousWeekTotal.Value) * 100;

            var formattedPercentageChange = Math.Round(percentageChange, 2);
            return formattedPercentageChange;
        }

        public async Task<Payment> CreatePaymentPayingCourse(string userId, float? totalMoney)
        {
            var payment = new Payment
            {
                Id = GenerateIdModel("payment"),
                UserId = userId,
                PaymendCode = GeneratePaymentCode(),
                CreateDate = GetTimeNow(),
                Total = totalMoney
            };
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return payment;
        }
        private string GeneratePaymentCode()
        {

            const string prefix = "PAY";

            string dateTimePart = DateTime.Now.ToString("yyyyMMddHHmmss");

            Random random = new Random();
            int randomPart = random.Next(1000, 9999);

            string paymentCode = $"{prefix}{dateTimePart}{randomPart}";

            return paymentCode;
        }

        public async Task CreatePaymentCourse(Payment payment, CartCourse cartCourse)
        {
            var paymentCourse = new PaymentCourse
            {
                Id = GenerateIdModel("paymentcourse"),
                Payment = payment,
                CartcourseId = cartCourse.Id,
                Total = cartCourse.Total
            };

            _context.PaymentCourses.Add(paymentCourse);
            await _context.SaveChangesAsync();
        }

        public async Task CreatePaymentAffiliate(CartCourse cartCourse, Affiliate affiliate)
        {
            var affiliatePayment = new AffiliatePayment
            {
                Id = GenerateIdModel("affiliatepayment"),
                UserId = affiliate.CreateBy,
                Cartcourse = cartCourse,
                Total = cartCourse.Total * affiliate.CommissionPercent,
                CreateDate = GetTimeNow()
            };
            _context.AffiliatePayments.Add(affiliatePayment);
            await _context.SaveChangesAsync();
        }
    }
}