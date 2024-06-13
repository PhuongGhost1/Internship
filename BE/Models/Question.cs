using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class Question
{
    public int Id { get; set; }

    public int? QuizId { get; set; }

    public string? Text { get; set; }

    public int? Mark { get; set; }

    public bool? Type { get; set; }

    public DateTime? CreateAt { get; set; }

    public virtual ICollection<Answear> Answears { get; set; } = new List<Answear>();

    public virtual Quiz? Quiz { get; set; }
}
