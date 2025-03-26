using UniversityCatalog.API.DTOs.Teachers;

namespace UniversityCatalog.API.DTOs.Roles;

public class RoleUpdateDto
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public List<TeacherDto>? Teachers { get; set; }
}