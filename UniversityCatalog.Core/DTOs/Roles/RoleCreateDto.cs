namespace UniversityCatalog.Core.DTOs.Roles;

public class RoleCreateDto
{
    public string Name { get; set; }
    public List<int> TeacherIds { get; set; }
}