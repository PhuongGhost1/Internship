using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class Comment
{
    public string Id { get; set; } = null!;

    public string? CourseId { get; set; }

    public string? UserId { get; set; }

    public int? Rating { get; set; }

    public string? Comment1 { get; set; }

    public DateTime? CreatedAt { get; set; }

    public bool? IsVisible { get; set; }

    public virtual Course? Course { get; set; }

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    public virtual User? User { get; set; }
}
