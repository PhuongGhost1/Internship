using BE.Dto.Course;

namespace BE.Dto.Certification
{
     public class CertificationDto
     {
          public string? Id { get; set; }
          public CourseForAdminDto? Course { get; set; }
          public string? Name { get; set; }
          public DateTime? CreateAt { get; set; }
     }
}