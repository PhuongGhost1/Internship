using System;
using System.Collections.Generic;
using BE.Dto.User;

namespace BE.Dto.Follow;

public class Followed
{
     public string? Id { get; set; }

    public UserInfoManageByAdminDto? FollowerId { get; set; }

    public UserInfoManageByAdminDto? FollowedId { get; set; }

    

}