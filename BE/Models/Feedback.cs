using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class Feedback
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    public virtual User? User { get; set; }
}
