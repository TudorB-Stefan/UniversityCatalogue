using UniversityCatalog.Core.Entities;

namespace UniversityCatalog.Core.DTOs.Grades;

public class GradeDto
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public decimal Value { get; set; }
    public GradeType GradeType { get; set; }
    public int CourseId { get; set; }
    public int StudentId { get; set; }
}