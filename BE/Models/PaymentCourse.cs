using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class PaymentCourse
{
    public string Id { get; set; } = null!;

    public string? PaymentId { get; set; }

    public string? CartcourseId { get; set; }

    public float? Total { get; set; }

    public virtual CartCourse? Cartcourse { get; set; }

    public virtual Payment? Payment { get; set; }
}
