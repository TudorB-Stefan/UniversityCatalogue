using System.Text.Json.Serialization;

namespace UniversityCatalog.Core.Entities;

public class Course
{
     public int Id { get; set; }
     public string Name { get; set; }
     public int? LecturerId { get; set; }
     [JsonIgnore]
     public Teacher? Lecturer { get; set; }
     [JsonIgnore]
     public List<CourseTeacher>? CourseTeachers { get; set; } = new();
     [JsonIgnore]
     public List<CourseStudent>? CourseStudents { get; set; } = new();
     [JsonIgnore]
     public List<Attendance>? Attendances { get; set; } = new();
     [JsonIgnore]
     public List<Grade>? Grades { get; set; } = new();
}