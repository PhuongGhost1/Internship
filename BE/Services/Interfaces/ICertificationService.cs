using BE.Dto.Certification;
using BE.Models;

namespace BE.Services.Interfaces
{
    public interface ICertificationService
    {
        

        //---------------------CRUD--------------------------//
        Task<List<Certification>> ViewAllCertifications();
        Task<Certification?> CreateCertification(string courseId, CreateCertificatonDto createCertificatonDto);
    }
}