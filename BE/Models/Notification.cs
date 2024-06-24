using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class Notification
{
    public string Id { get; set; } = null!;

    public string? ReceivedId { get; set; }

    public string? SenderId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public DateTime? DateUp { get; set; }

    public bool? IsRead { get; set; }

    public string? Type { get; set; }

    public string? CourseId { get; set; }

    public string? FeedbackId { get; set; }

    public string? CommentId { get; set; }

    public string? ReportId { get; set; }

    public int? Status { get; set; }

    public virtual Comment? Comment { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Feedback? Feedback { get; set; }

    public virtual User? Received { get; set; }

    public virtual Report? Report { get; set; }

    public virtual User? Sender { get; set; }
}
