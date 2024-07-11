
using BE.Models;

namespace BE.Repository.Interface
{
    public interface IResourcesRepository
    {


        //---------------------CRUD--------------------------//
        Task<Resource?> GetResourceById(string resId);
        Task<List<Resource>> GetAllResources();
        Task<Resource?> CreateResource(Resource resource);
        Task<Resource?> UpdateResource(Resource resource);
        Task<bool> DeleteResource(string resId);
    }
}