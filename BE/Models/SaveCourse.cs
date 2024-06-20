using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class SaveCourse
{
    public string Id { get; set; } = null!;

    public string? CourseId { get; set; }

    public string? UserId { get; set; }

    public DateTime? Time { get; set; }

    public virtual Course? Course { get; set; }

    public virtual User? User { get; set; }
}
