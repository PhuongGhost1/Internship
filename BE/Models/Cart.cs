using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class Cart
{
    public string Id { get; set; } = null!;

    public string? UserId { get; set; }

    public DateTime? DateCreated { get; set; }

    public float? Total { get; set; }

    public int? Status { get; set; }

    public virtual ICollection<CartCourse> CartCourses { get; set; } = new List<CartCourse>();

    public virtual User? User { get; set; }
}
