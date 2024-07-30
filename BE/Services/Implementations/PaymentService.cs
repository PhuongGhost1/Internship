using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Helpers;
using BE.Models;
using BE.Repository.Interface;
using BE.Services.Interfaces;
using static BE.Utils.Utils;

namespace BE.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly PaypalClient _paypalClient;
        private readonly IPaymentRepository _payRepo;
        private readonly ITransactionRepository _transactionRepository;
        private readonly ICartRepository _cartRepo;
        private readonly IUserRepository _userRepo;
        public PaymentService(PaypalClient paypalClient, IPaymentRepository payRepo, ITransactionRepository transactionRepository,
                            ICartRepository cartRepo, IUserRepository userRepo)
        {
            _paypalClient = paypalClient;
            _payRepo = payRepo;
            _transactionRepository = transactionRepository;
            _cartRepo = cartRepo;
            _userRepo = userRepo;
        }

        public async Task<CreateOrderResponse> CreateOrder(CreateOrderRequest request)
        {
            var orderResponse = await _paypalClient.CreateOrder(
                request.PurchaseUnits[0].Amount.Value, 
                request.PurchaseUnits[0].Amount.CurrencyCode, 
                request.PurchaseUnits[0].ReferenceId);

            var payment = new Payment
            {
                Id = GenerateIdModel("payment"),
                UserId = request.PurchaseUnits[0].ReferenceId,
                PaymendCode = orderResponse.Id,
                CreateDate = DateTime.UtcNow,
                Status = 0,
                Total = float.Parse(request.PurchaseUnits[0].Amount.Value)
            };
            await _payRepo.AddPayment(payment);

            return orderResponse;
        }

        public async Task<CaptureOrderResponse> CaptureOrder(string orderId)
        {
            var captureResponse = await _paypalClient.CaptureOrder(orderId);

            var paymentInfo = await _payRepo.GetPaymentInfoFromPaymentByPaymentCode(orderId) ?? new Payment();

            var transaction = new Transaction
            {
                Id = GenerateIdModel("transaction"),
                UserId = paymentInfo.UserId,
                PaymentId = paymentInfo.Id,
                DepositWithdrawalId = null,
                AffiliatePaymentId = null,
                CaptureOrderCode = captureResponse.PurchaseUnits[0].Payments.Captures[0].Id
            };

            var cartId = await _cartRepo.GetCartIdByUserId(paymentInfo.UserId);
            List<string> cartCourseId = await _cartRepo.GetCartCourseByCartId(cartId);

            foreach (var id in cartCourseId)
            {
                var paymentCourse = new PaymentCourse{
                    Id = GenerateIdModel("paymentcourse"),
                    PaymentId = paymentInfo.Id,
                    CartcourseId = id,
                    Total = paymentInfo.Total
                };
                await _payRepo.AddPaymentCourse(paymentCourse);
            }

            var user = await _userRepo.GetUserById(paymentInfo.UserId);
            if (user != null)
            {
                user.Wallet += paymentInfo.Total;
                await _userRepo.UpdateWalletForUser(user);
            }
            else
            {
                throw new Exception("User not found for user ID: " + paymentInfo.UserId);
            }

            await _userRepo.UpdateWalletForUser(user);

            await _payRepo.UpdateStatusPayment(paymentInfo.Id);

            await _transactionRepository.AddTransaction(transaction);

            return captureResponse;
        }

        public async Task<bool> CancelOrder(string orderId)
        {
            var paymentInfo = await _payRepo.GetPaymentInfoFromPaymentByPaymentCode(orderId);
            
            if (paymentInfo == null) return false;

            await _payRepo.DeletePaymentInfo(paymentInfo);

            return true;
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