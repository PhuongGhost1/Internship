using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class Report
{
    public string Id { get; set; } = null!;

    public string? CourseId { get; set; }

    public string? CommentId { get; set; }

    public string? ReportedUserId { get; set; }

    public string? ReporterId { get; set; }

    public string? Title { get; set; }

    public string? Message { get; set; }

    public int? Status { get; set; }

    public virtual Comment? Comment { get; set; }

    public virtual Course? Course { get; set; }

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual User? ReportedUser { get; set; }

    public virtual User? Reporter { get; set; }
}
