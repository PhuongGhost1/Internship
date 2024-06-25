namespace BE.Models;

public partial class Quiz
{
    public string Id { get; set; } = null!;

    public int? Index { get; set; }

    public string? ChapterId { get; set; }

    public string? Name { get; set; }

    public int? PassPercent { get; set; }

    public DateTime? CreateAt { get; set; }

    public int? NumberQuestions { get; set; }

    public int? TotalMark { get; set; }

    public int? Status { get; set; }

    public virtual Chapter? Chapter { get; set; }

    public virtual ICollection<Processing> Processings { get; set; } = new List<Processing>();

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    public virtual ICollection<Submission> Submissions { get; set; } = new List<Submission>();
}
