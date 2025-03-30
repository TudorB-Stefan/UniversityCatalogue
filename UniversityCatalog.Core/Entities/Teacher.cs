using System.Text.Json.Serialization;

namespace UniversityCatalog.Core.Entities;

public class Teacher : Person
{
    public int RoleId { get; set; }
    [JsonIgnore]
    public Role? Role { get; set; }
    [JsonIgnore]
    public List<CourseTeacher>? CourseTeachers { get; set; }
}