using System;
using System.Collections.Generic;

namespace BE.Dto.SaveCourse;

public  class UpdateSaveCourseDto
{
    public string Id { get; set; } = null!;

    public string? CourseId { get; set; }

    public string? UserId { get; set; }

}
