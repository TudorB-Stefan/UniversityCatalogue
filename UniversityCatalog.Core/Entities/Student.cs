namespace API.Models;

public class Student : Person
{
    public int CurrentYear { get; set; }
    public DateTime LastYear { get; set; }

    public List<Grade> Grades { get; set; } = new();
    public List<Attendance> Attendances { get; set; } = new();
    public List<CourseStudent> CourseStudents { get; set; } = new();
}