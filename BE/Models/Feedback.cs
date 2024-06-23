using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class Feedback
{
    public string Id { get; set; } = null!;

    public string? UserId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public bool? IsRead { get; set; }

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual User? User { get; set; }
}
