namespace API.Models;

public class Teacher : Person
{
    // OneToOne    Id,FirstName,LastName,Email,PhoneNumber,PfpImage,
    // OneToMany:  Course
    // ManyToMany: Roles
    
    public int RoleId { get; set; }
    public Role Role { get; set; }
    public List<Course> Courses { get; set; }
    public List<CourseTeacher> CourseTeachers { get; set; }
    // public List<CourseTeacher> Seminaries { get; set; }
    // public List<CourseTeacher> Labs { get; set; }
}