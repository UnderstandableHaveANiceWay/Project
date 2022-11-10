using Microsoft.AspNetCore.Mvc;
using ProjectV2.Bll.Interfaces;
using ProjectV2.Common.Dtos.Roles;

namespace ProjectV2.API.Controllers
{
    [Route("api/roles")]
    public class RoleController : AppBaseController
    {
        public readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleAsync([FromRoute]int id)
        {
            var roleDto = await _roleService.GetByIdAsync(id);
            if (roleDto is null)
            {
                return BadRequest();
            }
            return Ok(roleDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRolesAsync()
        {
            var roleDtos = await _roleService.GetAllAsync();
            return Ok(roleDtos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoleAsync([FromBody]RoleUpdateDto roleUpdateDto)
        {
            var roleDto = await _roleService.CreateRoleAsync(roleUpdateDto);
            if (roleDto is null)
            {
                return BadRequest();
            }
            return Ok(roleDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoleAsync([FromRoute]int id, [FromBody]RoleUpdateDto roleUpdateDto)
        {
            var roleDto = await _roleService.GetByIdAsync(id);
            if (roleDto is null)
            {
                return BadRequest();
            }
            await _roleService.UpdateRoleAsync(id, roleUpdateDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoleAsync([FromRoute]int id)
        {
            var roleDto = await _roleService.GetByIdAsync(id);
            if (roleDto is null)
            {
                return BadRequest();
            }
            await _roleService.DeleteRoleAsync(id);
            return Ok();
        }
    }
}
