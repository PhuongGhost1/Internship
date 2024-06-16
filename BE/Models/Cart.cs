using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class Cart
{
    public int Id { get; set; }

    public string? UserId { get; set; }

    public int? PaymentId { get; set; }

    public DateTime? DateCreated { get; set; }

    public float? Total { get; set; }

    public virtual ICollection<CartCourse> CartCourses { get; set; } = new List<CartCourse>();

    public virtual Payment? Payment { get; set; }

    public virtual User? User { get; set; }
}
