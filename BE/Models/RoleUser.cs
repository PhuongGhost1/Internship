using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class RoleUser
{
    public string Id { get; set; } = null!;

    public string? RoleId { get; set; }

    public string? UserId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? Status { get; set; }

    public virtual Role? Role { get; set; }

    public virtual User? User { get; set; }
}
