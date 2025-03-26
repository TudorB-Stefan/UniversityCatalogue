namespace API.Models;

public class Teacher : Person
{
    public int RoleId { get; set; }
    public Role Role { get; set; }
    public List<Course> Courses { get; set; }
    public List<CourseTeacher> CourseTeachers { get; set; }
}