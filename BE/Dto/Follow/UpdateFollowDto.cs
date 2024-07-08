using System;
using System.Collections.Generic;

namespace BE.Dto.Follow;

public class UpdateFollowDto
{
    public string Id { get; set; } = null!;

    public string? FollowerId { get; set; }

    public string? FollowedId { get; set; }

}
