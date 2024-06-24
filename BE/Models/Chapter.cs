using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class Chapter
{
    public string Id { get; set; } = null!;

    public int? Index { get; set; }

    public string? CourseId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateTime? CreateAt { get; set; }

    public int? Status { get; set; }

    public virtual Course? Course { get; set; }

    public virtual ICollection<Lecture> Lectures { get; set; } = new List<Lecture>();

    public virtual ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();
}
