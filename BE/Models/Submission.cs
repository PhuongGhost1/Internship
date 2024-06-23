using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class Submission
{
    public string Id { get; set; } = null!;

    public string? QuizId { get; set; }

    public string? UserId { get; set; }

    public double? Grade { get; set; }

    public DateTime? Date { get; set; }

    public bool? IsPass { get; set; }

    public virtual Quiz? Quiz { get; set; }

    public virtual User? User { get; set; }
}
