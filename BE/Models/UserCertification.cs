using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class UserCertification
{
    public string Id { get; set; } = null!;

    public string? UserId { get; set; }

    public string? CertificationId { get; set; }

    public DateTime? DatePass { get; set; }

    public virtual Certification? Certification { get; set; }

    public virtual User? User { get; set; }
}
