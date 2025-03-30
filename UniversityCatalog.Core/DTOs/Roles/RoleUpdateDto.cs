namespace UniversityCatalog.Core.DTOs.Roles;

public class RoleUpdateDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<int>? TeacherIds { get; set; }
}