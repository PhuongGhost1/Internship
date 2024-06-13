using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class Lecture
{
    public int Id { get; set; }

    public int? Index { get; set; }

    public int? ChapterId { get; set; }

    public string? Name { get; set; }

    public TimeOnly? TimeVideo { get; set; }

    public string? VideoUrl { get; set; }

    public DateTime? CreatAt { get; set; }

    public virtual Chapter? Chapter { get; set; }

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    public virtual ICollection<Processing> Processings { get; set; } = new List<Processing>();
}
