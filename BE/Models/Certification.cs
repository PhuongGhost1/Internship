using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class Certification
{
    public string Id { get; set; } = null!;

    public string? CourseId { get; set; }

    public string? Name { get; set; }

    public DateTime? CreateAt {get; set;}

    public virtual Course? Course { get; set; }

    public virtual ICollection<UserCertification> UserCertifications { get; set; } = new List<UserCertification>();
}
