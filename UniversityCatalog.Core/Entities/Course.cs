namespace API.Models;

public class Course
{
     // OneToOne:   Id,Name,Resources,LecturerId,Lecturer,List SeminaryProfesors,List LabProfesors
     // OneToMany:  Teachers(for Lectures), Grades, Attendance
     // ManyToMany: Teachers(for Seminaries,Labs)
     
     public int Id { get; set; }
     public string Name { get; set; }
     
     public int LecturerId { get; set; }
     public Teacher Lecturer { get; set; }

     public List<CourseTeacher> CourseTeachers { get; set; }

     public List<Attendance> Attendances { get; set; }
     public List<Grade> Grades { get; set; }
}