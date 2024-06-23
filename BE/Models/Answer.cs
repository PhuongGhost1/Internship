using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class Answer
{
    public string Id { get; set; } = null!;

    public string? QuestionId { get; set; }

    public string? Text { get; set; }

    public int? Status { get; set; }

    public bool? IsCorrect { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Question? Question { get; set; }
}
