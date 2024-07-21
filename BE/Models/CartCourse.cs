using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class CartCourse
{
    public string Id { get; set; } = null!;

    public string? CartId { get; set; }

    public string? CourseId { get; set; }

    public string? AffiliateId { get; set; }

    public float? Total { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? Status { get; set; }

    public virtual Affiliate? Affiliate { get; set; }

    public virtual AffiliatePayment? AffiliatePayment { get; set; }

    public virtual Cart? Cart { get; set; }

    public virtual Course? Course { get; set; }

    public virtual PaymentCourse? PaymentCourse { get; set; }
}
