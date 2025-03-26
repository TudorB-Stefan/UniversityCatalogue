using API.Models;
using UniversityCatalog.API.DTOs.Courses;
using UniversityCatalog.API.DTOs.Students;

namespace UniversityCatalog.API.DTOs.Grades;

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