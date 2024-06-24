using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class Processing
{
    public string Id { get; set; } = null!;

    public string? UserId { get; set; }

    public string? LectureId { get; set; }

    public string? QuizId { get; set; }

    public DateTime? CreateAt { get; set; }

    public virtual Lecture? Lecture { get; set; }

    public virtual Quiz? Quiz { get; set; }

    public virtual User? User { get; set; }
}
