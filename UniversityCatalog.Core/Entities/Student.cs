using System.Text.Json.Serialization;

namespace UniversityCatalog.Core.Entities;

public class Student : Person
{
    public int CurrentYear { get; set; }
    // public DateTime? LastYear { get; set; }
    [JsonIgnore]
    public List<Grade>? Grades { get; set; } = new();
    [JsonIgnore]
    public List<Attendance>? Attendances { get; set; } = new();
    [JsonIgnore]
    public List<CourseStudent>? CourseStudents { get; set; } = new();
}