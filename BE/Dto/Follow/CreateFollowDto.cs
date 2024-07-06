using System;
using System.Collections.Generic;

namespace BE.Dto.Follow;

public class CreateFollowDto
{
    public string? FollowerId { get; set; }

    public string? FollowedId { get; set; }

}
