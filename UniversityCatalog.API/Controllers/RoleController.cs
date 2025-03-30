using Microsoft.AspNetCore.Mvc;
using UniversityCatalog.Core.DTOs.Roles;
using UniversityCatalog.Core.Entities;
using UniversityCatalog.Core.Interfaces.Services;

namespace UniversityCatalog.API.Controllers;

[ApiController]
[Route("api/roles")]
public class RoleController(IRoleService roleService):ControllerBase
{
    private readonly IRoleService _roleService=roleService;
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Role>>> GetAllRolesAsync()
    {
        var roles = await _roleService.GetAllRolesAsync();
        return Ok(roles);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Role>> GetRoleByIdAsync(int id)
    {
        var role = await _roleService.GetRoleByIdAsync(id);
        return Ok(role);
    }
    [HttpPost]
    public async Task<IActionResult> CreateRoleAsync(RoleCreateDto roleDto)
    {
        var newRole = _roleService.CreateRoleAsync(roleDto);
        return Ok(newRole);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRoleAsync(RoleUpdateDto roleDto)
    {
        var updatedRole = _roleService.UpdateRoleAsync(roleDto);
        return Ok(updatedRole);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRoleAsync(int id)
    {
        await _roleService.DeleteRoleAsync(id);
        return NoContent();
    }
}