using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class CategoryCourse
{
    public string Id { get; set; } = null!;

    public string? CategoryId { get; set; }

    public string? CourseId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Course? Course { get; set; }
}
