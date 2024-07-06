using System;
using System.Collections.Generic;

namespace BE.Dto.CategoryCourse;

public class UpdateCategoryCourseDto
{
    public string Id { get; set; } = null!;
    public string? CategoryId { get; set; }

    public string? CourseId { get; set; }

}
