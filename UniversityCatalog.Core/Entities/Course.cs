namespace API.Models;

public class Course
{
     public int Id { get; set; }
     public string Name { get; set; }
     
     public int LecturerId { get; set; }
     public Teacher Lecturer { get; set; }

     public List<CourseTeacher> CourseTeachers { get; set; } = new();
     public List<CourseStudent> CourseStudents { get; set; } = new();

     public List<Attendance> Attendances { get; set; } = new();
     public List<Grade> Grades { get; set; } = new();
}