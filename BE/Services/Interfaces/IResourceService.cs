using BE.Dto.Resources;
using BE.Models;

namespace BE.Services.Interfaces
{
    public interface IResourceService
    {
        

        //---------------------CRUD--------------------------//
        Task<List<Resource>> GetAllResources();
        Task<Resource?> CreateResource(CreateResourceDto createResourceDto);
        Task<Resource?> UpdateResource(string resId, UpdateResourceDto updateResourceDto);
        Task<bool> DeleteResource(string resId);
    }
}