using System.Collections.Generic;
using System.Threading.Tasks;
using BE.Attributes;
using BE.Models;
using BE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    [Route("api/v1/permissons")]
    [ApiController]
    public class PermissonController : ControllerBase
    {
        private readonly IPermissonService _permissonService;

        public PermissonController(IPermissonService permissonService)
        {
            _permissonService = permissonService;
        }


        [CustomAuthorize("Super Admin")]
        [HttpGet]
        
        public async Task<ActionResult<IEnumerable<Permisson>>> GetAllPermissons()
        {
            var permissons = await _permissonService.GetAllPermissonsAsync();
            return Ok(permissons);
        }

        [CustomAuthorize("Super Admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Permisson>> GetPermissonById(string id)
        {
            var permisson = await _permissonService.GetPermissonByIdAsync(id);
            return Ok(permisson);
        }

        [CustomAuthorize("Super Admin")]
        [HttpPost]
        public async Task<ActionResult> AddPermisson(Permisson permisson)
        {
            await _permissonService.AddPermissonAsync(permisson);
            return CreatedAtAction(nameof(GetPermissonById), new { id = permisson.Id }, permisson);
        }

        [CustomAuthorize("Super Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePermisson(string id, Permisson permisson)
        {
            await _permissonService.UpdatePermissonAsync(permisson);
            return NoContent();
        }

        [CustomAuthorize("Super Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePermisson(string id)
        {
            await _permissonService.DeletePermissonAsync(id);
            return NoContent();
        }
    }
}
