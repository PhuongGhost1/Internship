using System;
using System.Collections.Generic;
using BE.Dto.ImageD;
using BE.Dto.User;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BE.Dto.Follow;

public class FollowingDto
{
     public string? FollowingListOfUserId { get; set; }
     public List<UserInfoManageByAdminDto> FollowFolloweds { get; set; } = new List<UserInfoManageByAdminDto>();
     public List<UserInfoManageByAdminDto> FollowFollowers { get; set; } = new List<UserInfoManageByAdminDto>();
}
