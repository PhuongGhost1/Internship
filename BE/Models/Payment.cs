using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class Payment
{
    public string Id { get; set; } = null!;

    public string? UserId { get; set; }

    public string? PaymendCode { get; set; }

    public DateTime? CreateDate { get; set; }

    public float? Total { get; set; }
    
    public int? Status {get; set;}

    public virtual ICollection<PaymentCourse> PaymentCourses { get; set; } = new List<PaymentCourse>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual User? User { get; set; }
}
