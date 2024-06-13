using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class Resource
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Permisson> Permissons { get; set; } = new List<Permisson>();
}
