using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class Notification
{
    public int Id { get; set; }

    public string? ReceivedId { get; set; }

    public string? SenderId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public DateTime? DateUp { get; set; }

    public bool? IsRead { get; set; }

    public virtual User? Received { get; set; }

    public virtual User? Sender { get; set; }
}
