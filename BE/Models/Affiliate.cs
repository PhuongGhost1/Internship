using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class Affiliate
{
    public string Id { get; set; } = null!;

    public DateTime? CreateAt { get; set; }

    public float? CommissionPercent { get; set; }

    public string? CreateBy { get; set; }

    public string? CourseId { get; set; }

    public virtual ICollection<CartCourse> CartCourses { get; set; } = new List<CartCourse>();

    public virtual Course? Course { get; set; }

    public virtual User? CreateByNavigation { get; set; }
}
