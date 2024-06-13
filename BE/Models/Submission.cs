using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class Submission
{
    public int Id { get; set; }

    public int? QuizzId { get; set; }

    public string? UserId { get; set; }

    public double? Grade { get; set; }

    public DateTime? Date { get; set; }

    public virtual Quiz? Quizz { get; set; }

    public virtual User? User { get; set; }
}
