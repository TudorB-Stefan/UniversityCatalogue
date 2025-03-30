namespace UniversityCatalog.Core.DTOs.Courses;

public class CourseUpdateDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int LecturerId { get; set; }
    public List<int>? TeachersIds { get; set; }
    public List<int>? StudentsIds { get; set; }
    public List<int>? AttendanceIds { get; set; }
    public List<int>? GradeIds { get; set; }
    
}