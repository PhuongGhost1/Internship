using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class Category
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public virtual ICollection<CategoryCourse> CategoryCourses { get; set; } = new List<CategoryCourse>();
}
