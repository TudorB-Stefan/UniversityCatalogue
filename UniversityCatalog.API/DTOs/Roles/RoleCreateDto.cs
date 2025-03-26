using UniversityCatalog.API.DTOs.Teachers;

namespace UniversityCatalog.API.DTOs.Roles;

public class RoleCreateDto
{
    public string Name { get; set; }
    public List<TeacherDto> Teachers { get; set; }
}