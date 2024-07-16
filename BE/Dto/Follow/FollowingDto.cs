using System;
using System.Collections.Generic;
using BE.Dto.User;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BE.Dto.Follow;

public class FollowingDto
{
    public string FollowId { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public List<BasicInfoUser> ListFollower { get; set; } = null!;
    public string Name { get; set; }

    public List<string> ListImage { get; set; }

    public int Follower { get; set; } = 0!;

    public int Course { get; set; } = 0!;

}
