using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class Quiz
{
    public int Id { get; set; }

    public int? Index { get; set; }

    public int? ChapterId { get; set; }

    public string? Name { get; set; }

    public int? PassPercent { get; set; }

    public DateTime? CreateAt { get; set; }

    public int? NumberOfQuestions { get; set; }

    public int? TotalMark { get; set; }

    public virtual Chapter? Chapter { get; set; }

    public virtual ICollection<Processing> Processings { get; set; } = new List<Processing>();

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    public virtual ICollection<Submission> Submissions { get; set; } = new List<Submission>();
}
