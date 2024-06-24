using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class Answear
{
    public int Id { get; set; }

    public int? QuestionId { get; set; }

    public string? Text { get; set; }

    public bool? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Question? Question { get; set; }
}
