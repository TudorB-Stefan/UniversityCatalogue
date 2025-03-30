using UniversityCatalog.Core.DTOs.Teachers;

namespace UniversityCatalog.Core.DTOs.Roles;

public class RoleDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<TeacherDto> Teachers { get; set; }
}