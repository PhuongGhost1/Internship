using BE.Dto.Resources;
using BE.Mappers;
using BE.Models;
using BE.Repository.Interface;
using BE.Services.Interfaces;

namespace BE.Services.Implementations
{
    public class ResourceService : IResourceService
    {
        private readonly IResourcesRepository _resRepo;
        public ResourceService(IResourcesRepository resRepo)
        {
            _resRepo = resRepo;
        }



        //---------------------CRUD--------------------------//
        public async Task<Resource?> CreateResource(CreateResourceDto createResourceDto)
        {
            var createResource = createResourceDto.ToCreateResourceDto();

            if(createResource == null) throw new Exception("Unable to create resource!");

            return await _resRepo.CreateResource(createResource);
        }

        public async Task<bool> DeleteResource(string resId)
        {
            var resource = await _resRepo.GetResourceById(resId);

            if(resource == null) throw new Exception("Unable to find resource!");

            return await _resRepo.DeleteResource(resId);
        }

        public async Task<List<Resource>> GetAllResources()
        {
            return await _resRepo.GetAllResources();
        }

        public async Task<Resource?> UpdateResource(string resId, UpdateResourceDto updateResourceDto)
        {
            var resource = await _resRepo.GetResourceById(resId);

            if(resource == null) throw new Exception("Unable to find resource!");

            var updateResource = updateResourceDto.ToUpdateResourceDto();

            if(updateResource == null) throw new Exception("Unable to update resource!");

            return await _resRepo.UpdateResource(updateResource);
        }
    }
}