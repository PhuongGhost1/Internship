using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class SaveCourse
{
    public int Id { get; set; }

    public int? CourseId { get; set; }

    public int? UserId { get; set; }

    public DateTime? Time { get; set; }

    public virtual Course? Course { get; set; }

    public virtual User? User { get; set; }
}
