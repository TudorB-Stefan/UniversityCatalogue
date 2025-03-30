using UniversityCatalog.Core.DTOs.Courses;
using UniversityCatalog.Core.DTOs.Students;

namespace UniversityCatalog.Core.DTOs.Attendances;

public class AttendanceDto
{
    public DateTime Date { get; set; }
    public bool IsPresent { get; set; }
    public int StudentId { get; set; }
    public StudentDto Student { get; set; }
    public int CourseId { get; set; }
    public CourseDto Course { get; set; }
    public string CourseType { get; set; }
}