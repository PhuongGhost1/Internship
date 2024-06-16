using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class Processing
{
    public int Id { get; set; }

    public string? UserId { get; set; }

    public int? LectureId { get; set; }

    public int? QuizId { get; set; }

    public DateTime? CreateAt { get; set; }

    public virtual Lecture? Lecture { get; set; }

    public virtual Quiz? Quiz { get; set; }

    public virtual User? User { get; set; }
}
