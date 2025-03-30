using UniversityCatalog.Core.DTOs.Attendances;
using UniversityCatalog.Core.DTOs.Courses;
using UniversityCatalog.Core.DTOs.Grades;

namespace UniversityCatalog.Core.DTOs.Students;

public class StudentDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public int CurrentYear { get; set; }
    // public DateTime LastYear { get; set; }
    public List<GradeDto> Grades { get; set; }
    public List<AttendanceDto> Attendances { get; set; }
    public List<CourseDto> Courses { get; set; }
}