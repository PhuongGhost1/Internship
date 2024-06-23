using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class EnrollCourse
{
    public string Id { get; set; } = null!;

    public string? UserId { get; set; }

    public string? CourseId { get; set; }

    public DateTime? Date { get; set; }

    public virtual Course? Course { get; set; }

    public virtual User? User { get; set; }
}
