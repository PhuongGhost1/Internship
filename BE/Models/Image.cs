using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class Image
{
    public string Id { get; set; } = null!;

    public string? UserId { get; set; }

    public string? CourseId { get; set; }

    public string? LectureId { get; set; }

    public string? FeedbackId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Url { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Feedback? Feedback { get; set; }

    public virtual Lecture? Lecture { get; set; }

    public virtual User? User { get; set; }
}
