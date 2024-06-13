using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class CartCourse
{
    public int Id { get; set; }

    public int? CartId { get; set; }

    public int? CourseId { get; set; }

    public int? AffiliateId { get; set; }

    public float? Total { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Affiliate? Affiliate { get; set; }

    public virtual Cart? Cart { get; set; }

    public virtual Course? Course { get; set; }
}
