using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class Certification
{
    public int Id { get; set; }

    public int? CourseId { get; set; }

    public string? Name { get; set; }

    public virtual Course? Course { get; set; }

    public virtual ICollection<UserCertification> UserCertifications { get; set; } = new List<UserCertification>();
}
