using UniversityCatalog.API.DTOs.Attendances;
using UniversityCatalog.API.DTOs.Grades;
using UniversityCatalog.API.DTOs.Students;
using UniversityCatalog.API.DTOs.Teachers;

namespace UniversityCatalog.API.DTOs.Courses;

public class CourseCreateDto
{
    public string Name { get; set; }
    public int LecturerId { get; set; }
    public TeacherDto Lecturer { get; set; }
    public List<TeacherDto> CourseTeachers { get; set; } = new();
    public List<StudentDto> CourseStudents { get; set; } = new();
    public List<AttendanceDto> Attendances { get; set; } = new();
    public List<GradeDto> Grades { get; set; } = new();
}