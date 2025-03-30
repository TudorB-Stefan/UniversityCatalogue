using UniversityCatalog.Core.DTOs.Roles;
using UniversityCatalog.Core.Entities;
using UniversityCatalog.Core.Interfaces;
using UniversityCatalog.Core.Interfaces.Services;

namespace UniversityCatalog.Infrastructure.Services;

public class RoleService(IGenericRepository<Role> roleRepository) : IRoleService
{
    private readonly IGenericRepository<Role> _roleRepository = roleRepository;
    public async Task<IReadOnlyList<Role>> GetAllRolesAsync()
    {
        return await _roleRepository.GetAllAsync();
    }

    public async Task<Role> GetRoleByIdAsync(int id)
    {
        return await _roleRepository.GetByIdAsync(id);
    }

    public async Task<Role> CreateRoleAsync(RoleCreateDto roleDto)
    {
        var addedRole = new Role
        {

        };
        await _roleRepository.AddAsync(addedRole);
        return addedRole;
    }

    public async Task<Role> UpdateRoleAsync(RoleUpdateDto roleDto)
    {
        if(roleDto == null)
            throw new KeyNotFoundException("Role not found!");
        var updatedRole = await _roleRepository.GetByIdAsync(roleDto.Id);
        updatedRole.Id = roleDto.Id;
        updatedRole.Name = roleDto.Name;
        updatedRole.Teachers = roleDto.TeacherIds.Select(teacherId => new Teacher {Id = teacherId}).ToList();
        await _roleRepository.UpdateAsync(updatedRole);
        return updatedRole;
    }

    public async Task DeleteRoleAsync(int id)
    {
        await _roleRepository.DeleteAsync(id);
    }
}