using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class Image
{
    public int Id { get; set; }

    public string? Base64Code { get; set; }

    public string? UserId { get; set; }

    public int? CourseId { get; set; }

    public int? LectureId { get; set; }

    public int? FeedbackId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Feedback? Feedback { get; set; }

    public virtual Lecture? Lecture { get; set; }

    public virtual User? User { get; set; }
}
