using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BE.Dto.Follow;

public class FollowingDto
{
    public string FolloweId { get; set; } = null!;
    public string UserId { get; set; } = null!;

    public string Name { get; set; }

    public List<string> ListImage { get; set; }

    public int Follower { get; set; } = 0!;

    public int Course { get; set; } = 0!;

}
