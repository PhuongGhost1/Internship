using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class DepositWithdrawal
{
    public string Id { get; set; } = null!;

    public string? UserId { get; set; }

    public string? Type { get; set; }

    public string? TransactionMethod { get; set; }

    public float? Total { get; set; }

    public DateTime? CreateDate { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual User? User { get; set; }
}
