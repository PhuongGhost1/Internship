
namespace BE.Dto.EnrollCourse;

public class UpdateEnrollCourseDto
{
    public string Id { get; set; } = null!;
    public string? UserId { get; set; }
    public string? CourseId { get; set; }

}
