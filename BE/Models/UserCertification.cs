using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class UserCertification
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? CertificationId { get; set; }

    public DateTime? DatePass { get; set; }

    public virtual Certification? Certification { get; set; }

    public virtual User? User { get; set; }
}
