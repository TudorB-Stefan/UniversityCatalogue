using UniversityCatalog.API.DTOs.Roles;

namespace UniversityCatalog.API.DTOs.Teachers;

public class TeacherUpdateDto
{
    public int? Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public int? CurrentYear { get; set; }
    public DateTime? LastYear { get; set; }
    public RoleDto? Role { get; set; }
    
}