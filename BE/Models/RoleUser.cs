using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class RoleUser
{
    public int Id { get; set; }

    public int? RoleId { get; set; }

    public string? UserId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual Role? Role { get; set; }

    public virtual User? User { get; set; }
}
