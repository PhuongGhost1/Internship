using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class Follow
{
    public string Id { get; set; } = null!;

    public string? FollowerId { get; set; }

    public string? FollowedId { get; set; }

    public DateTime? Time { get; set; }

    public virtual User? Followed { get; set; }

    public virtual User? Follower { get; set; }
}
