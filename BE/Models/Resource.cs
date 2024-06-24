using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class Resource
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public virtual ICollection<Permisson> Permissons { get; set; } = new List<Permisson>();
}
