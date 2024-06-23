using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class Role
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public virtual ICollection<Permisson> Permissons { get; set; } = new List<Permisson>();

    public virtual ICollection<RoleUser> RoleUsers { get; set; } = new List<RoleUser>();
}
