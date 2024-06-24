using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class Question
{
    public string Id { get; set; } = null!;

    public string? QuizId { get; set; }

    public string? Text { get; set; }

    public int? Mark { get; set; }

    public bool? Type { get; set; }

    public DateTime? CreateAt { get; set; }

    public int? Status { get; set; }

    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    public virtual Quiz? Quiz { get; set; }
}
