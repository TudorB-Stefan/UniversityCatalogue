using UniversityCatalog.Core.DTOs.Roles;
using UniversityCatalog.Core.Entities;

namespace UniversityCatalog.Core.Interfaces.Services;

public interface IRoleService
{
    Task<IReadOnlyList<Role>> GetAllRolesAsync();
    Task<Role> GetRoleByIdAsync(int id);
    Task<Role> CreateRoleAsync(RoleCreateDto roleDto);
    Task<Role> UpdateRoleAsync(RoleUpdateDto roleDto);
    Task DeleteRoleAsync(int id);
}