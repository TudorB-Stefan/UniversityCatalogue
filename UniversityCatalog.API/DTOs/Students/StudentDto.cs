using API.Models;
using UniversityCatalog.API.DTOs.Attendances;
using UniversityCatalog.API.DTOs.Courses;
using UniversityCatalog.API.DTOs.Grades;

namespace UniversityCatalog.API.DTOs.Students;

public class StudentDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public int CurrentYear { get; set; }
    public DateTime LastYear { get; set; }
    public List<GradeDto> Grades { get; set; }
    public List<AttendanceDto> Attendances { get; set; }
    public List<CourseDto> Courses { get; set; }
}