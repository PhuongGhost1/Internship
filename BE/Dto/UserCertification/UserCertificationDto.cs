using BE.Dto.Certification;
using BE.Dto.User;

namespace BE.Dto.UserCertification{
     public class UserCertificationDto{
          public string? Id { get; set; }
          public UserInfoManageByAdminDto? User { get; set; }
          public CertificationDto? Certification { get; set; }
          public DateTime? DatePass { get; set; }
     }
}