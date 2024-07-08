
using BE.Models;

namespace BE.Repository.Interface
{
    public interface ICertificationRepository
    {


        //---------------------CRUD--------------------------//
        Task<List<Certification>> GetAllCertifications();
        Task<Certification?> CreateCertification(Certification certification);
    }
}