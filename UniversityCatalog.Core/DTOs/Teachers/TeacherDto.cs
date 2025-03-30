using UniversityCatalog.Core.DTOs.Courses;
using UniversityCatalog.Core.DTOs.Roles;

namespace UniversityCatalog.Core.DTOs.Teachers;

public class TeacherDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public int CurrentYear { get; set; }
    public DateTime LastYear { get; set; }
    public int RoleId { get; set; }
    public RoleDto Role { get; set; }
    public List<CourseDto> Courses { get; set; }
    public List<TeacherDto> CourseTeachers { get; set; }
}