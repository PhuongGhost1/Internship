
using BE.Models;

namespace BE.Repository.Interface
{
    public interface ICertificationRepository
    {
        Task<List<Certification>> GetUserCertifications(string userId);


        //---------------------CRUD--------------------------//
        Task<List<Certification>> GetAllCertifications();
        Task<Certification?> CreateCertification(Certification certification);
    }
}