using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class Affiliate
{
    public int Id { get; set; }

    public int? CreateAt { get; set; }

    public float? CommissionPercent { get; set; }

    public string? CreateBy { get; set; }

    public int? CourseId { get; set; }

    public float? TotalCommission { get; set; }

    public virtual ICollection<CartCourse> CartCourses { get; set; } = new List<CartCourse>();

    public virtual Course? Course { get; set; }

    public virtual User? CreateByNavigation { get; set; }
}
