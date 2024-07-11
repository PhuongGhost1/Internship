using BE.Dto.UserCertification;
using BE.Models;
using static BE.Utils.Utils;

namespace BE.Mappers
{
    public static class UserCertificationMappers
    {
        public static UserCertification ToCreateUserCertification(this CreateUserCertificationDto createUserCertificationDto){
            return new UserCertification{
                Id = GenerateIdModel("savecourse"),
                CertificationId = createUserCertificationDto.CertificationId,
                UserId = createUserCertificationDto.UserId,
                DatePass = GetTimeNow()
            };
        }

        public static UserCertification ToUpdateUserCertification(this UpdateUserCertificationDto updateUserCertificationDto){
            return new UserCertification{
                CertificationId = updateUserCertificationDto.CertificationId,
                UserId = updateUserCertificationDto.UserId,
                DatePass = GetTimeNow()
            };
        }
    }
}