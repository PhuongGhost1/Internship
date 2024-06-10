using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class Payment
{
    public int Id { get; set; }

    public string? PaymentMethod { get; set; }

    public string? PaymendCode { get; set; }

    public DateTime? Date { get; set; }

    public float? Total { get; set; }

    public virtual Cart? Cart { get; set; }
}
