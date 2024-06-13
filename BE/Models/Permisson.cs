using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class Permisson
{
    public int Id { get; set; }

    public int? RoleId { get; set; }

    public int? ResourcesId { get; set; }

    public DateTime? LastUpdate { get; set; }

    public bool? Create { get; set; }

    public bool? Delete { get; set; }

    public bool? Update { get; set; }

    public bool? View { get; set; }

    public virtual Resource? Resources { get; set; }

    public virtual Role? Role { get; set; }
}
