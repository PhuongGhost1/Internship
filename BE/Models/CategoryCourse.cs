using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class CategoryCourse
{
    public int Id { get; set; }

    public int? CategoryId { get; set; }

    public int? CourseId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Course? Course { get; set; }
}
