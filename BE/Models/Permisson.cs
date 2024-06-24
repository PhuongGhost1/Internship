using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class Permisson
{
    public string Id { get; set; } = null!;

    public string? RoleId { get; set; }

    public string? ResourcesId { get; set; }

    public DateTime? LastUpdate { get; set; }

    public string? LastEditor { get; set; }

    public bool? Request { get; set; }

    public bool? Create { get; set; }

    public bool? Delete { get; set; }

    public bool? Update { get; set; }

    public bool? View { get; set; }

    public virtual Resource? Resources { get; set; }

    public virtual Role? Role { get; set; }
}
