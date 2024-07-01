using System.Collections.Generic;
using System.Threading.Tasks;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Permisson>>> GetAllPermissons()
        {
            var permissons = await _permissonService.GetAllPermissonsAsync();
            return Ok(permissons);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Permisson>> GetPermissonById(string id)
        {
            var permisson = await _permissonService.GetPermissonByIdAsync(id);
            return Ok(permisson);
        }

        [HttpPost]
        public async Task<ActionResult> AddPermisson(Permisson permisson)
        {
            await _permissonService.AddPermissonAsync(permisson);
            return CreatedAtAction(nameof(GetPermissonById), new { id = permisson.Id }, permisson);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePermisson(string id, Permisson permisson)
        {
            if (id != permisson.Id)
            {
                return BadRequest("The permisson ID in the URL does not match the ID in the permisson data.");
            }

            await _permissonService.UpdatePermissonAsync(permisson);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePermisson(string id)
        {
            await _permissonService.DeletePermissonAsync(id);
            return NoContent();
        }
    }
}
