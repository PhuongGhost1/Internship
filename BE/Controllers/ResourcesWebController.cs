using BE.Dto.Resources;
using BE.Models;
using BE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    [ApiController]
    [Route("api/v1/web/resource")]
    public class ResourcesWebController
    {
        private readonly IResourceService _resService;
        public ResourcesWebController(IResourceService resService)
        {
            _resService = resService;
        }

        //---------------------CRUD--------------------------//
        [HttpGet]
        [Route("view-all-resources")]
        public async Task<List<Resource>> ViewAllResources(){
            return await _resService.GetAllResources();
        }

        [HttpPost]
        [Route("create-resource")]
        public async Task<Resource?> CreateResource([FromForm] CreateResourceDto createResourceDto){
            return await _resService.CreateResource(createResourceDto);
        }

        [HttpPost]
        [Route("update-resource")]
        public async Task<Resource?> UpdateResource([FromForm] string resId, [FromForm] UpdateResourceDto updateResourceDto){
            return await _resService.UpdateResource(resId, updateResourceDto);
        }

        [HttpPost]
        [Route("delete-resource")]
        public async Task<bool> CreateResource([FromForm] string resId){
            return await _resService.DeleteResource(resId);
        }
    }
}