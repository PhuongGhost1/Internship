using System;
using System.Collections.Generic;
using BE.Dto.ImageD;
using BE.Dto.User;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BE.Dto.Follow;

public class FollowingDto
{
     public string? FollowingListOfUserId { get; set; }
     public List<UserInfoFollowingDto> FollowFolloweds { get; set; } = new List<UserInfoFollowingDto>();
     public List<UserInfoFollowingDto> FollowFollowers { get; set; } = new List<UserInfoFollowingDto>();
}
