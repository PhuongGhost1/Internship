using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class Follow
{
    public int Id { get; set; }

    public int? FollowerId { get; set; }

    public int? FollowedId { get; set; }

    public DateTime? Time { get; set; }

    public virtual User? Followed { get; set; }

    public virtual User? Follower { get; set; }
}
