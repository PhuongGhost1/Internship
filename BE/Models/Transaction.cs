using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class Transaction
{
    public string Id { get; set; } = null!;

    public string? UserId { get; set; }

    public string? DepositWithdrawalId { get; set; }

    public string? AffiliatePaymentId { get; set; }

    public string? PaymentId { get; set; }

    public string? CaptureOrderCode {get; set;}

    public virtual AffiliatePayment? AffiliatePayment { get; set; }

    public virtual DepositWithdrawal? DepositWithdrawal { get; set; }

    public virtual Payment? Payment { get; set; }

    public virtual User? User { get; set; }
}
