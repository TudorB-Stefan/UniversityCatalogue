using UniversityCatalog.Core.DTOs.Courses;
using UniversityCatalog.Core.DTOs.Students;
using UniversityCatalog.Core.Entities;

namespace UniversityCatalog.Core.DTOs.Grades;

public class GradeCreateDto
{
    public DateTime Date { get; set; }
    public decimal Value { get; set; }
    public GradeType GradeType { get; set; }
    public int CourseId { get; set; }
    public CourseDto Course { get; set; }
    public int StudentId { get; set; }
    public StudentDto Student { get; set; }
}