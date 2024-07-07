using BE.Dto.Certification;
using BE.Models;
using static BE.Utils.Utils;

namespace BE.Mappers
{
    public static class CertificationMappers
    {
        public static Certification ToCreateCertificationDto(this CreateCertificatonDto createCertificatonDto, string courseId){
            return new Certification{
                Id = GenerateIdModel("certification"),
                CreateAt = GetTimeNow(),
                CourseId = courseId,
                Name = createCertificatonDto.Name
            };
        }
    }
}