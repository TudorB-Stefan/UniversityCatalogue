using UniversityCatalog.Core.DTOs.Attendances;
using UniversityCatalog.Core.DTOs.Grades;
using UniversityCatalog.Core.DTOs.Students;
using UniversityCatalog.Core.DTOs.Teachers;

namespace UniversityCatalog.Core.DTOs.Courses;

public class CourseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int LecturerId { get; set; }
    public TeacherDto Lecturer { get; set; }
    public List<TeacherDto> CourseTeachers { get; set; } = new();
    public List<StudentDto> CourseStudents { get; set; } = new();
    public List<AttendanceDto> Attendances { get; set; } = new();
    public List<GradeDto> Grades { get; set; } = new();
}