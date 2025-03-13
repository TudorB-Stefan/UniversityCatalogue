namespace API.Models;

public class Student : Person
{
    // OneToOne:   Id,YearProgression,FirstName,LastName,Email,PhoneNumber,PfpImage,
    // OneToMany:  Grade
    // ManyToMany: Courses(enrollment), Attendance(Student<->Course)
    
    public int CurrentYear { get; set; }
    public DateTime LastYear { get; set; }
    
    public List<Grade> Grades { get; set; }
    public List<Attendance> Attendances { get; set; }
}