namespace UniversityCatalog.Core.DTOs.Attendances;

public class AttendanceUpdateDto
{
    public DateTime Date { get; set; }
    public bool IsPresent { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public string CourseType { get; set; }
}