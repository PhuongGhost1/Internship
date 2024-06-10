using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class Report
{
    public int Id { get; set; }

    public int? CourseId { get; set; }

    public int? CommentId { get; set; }

    public int? ReportedUserId { get; set; }

    public int? ReporterId { get; set; }

    public string? Title { get; set; }

    public string? Message { get; set; }

    public virtual Comment? Comment { get; set; }

    public virtual Course? Course { get; set; }

    public virtual User? ReportedUser { get; set; }

    public virtual User? Reporter { get; set; }
}
