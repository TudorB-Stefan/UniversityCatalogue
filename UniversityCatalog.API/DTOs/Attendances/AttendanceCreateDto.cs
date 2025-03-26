using UniversityCatalog.API.DTOs.Courses;
using UniversityCatalog.API.DTOs.Students;

namespace UniversityCatalog.API.DTOs.Attendances;

public class AttendanceCreateDto
{
    public DateTime Date { get; set; }
    public bool IsPresent { get; set; }
    public int StudentId { get; set; }
    public StudentDto Student { get; set; }
    public int CourseId { get; set; }
    public CourseDto Course { get; set; }
    public string CourseType { get; set; }
}