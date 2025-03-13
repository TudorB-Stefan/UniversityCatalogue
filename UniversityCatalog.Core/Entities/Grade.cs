namespace API.Models;

public class Grade
{
    // Id,DateTime,StudentId,Student,CourseId,Course,Value,GradeType(couse,seminary,lab)
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public float Value { get; set; }
    public string GradeType { get; set; }
    
    public int CourseId { get; set; }
    public Course Course { get; set; }
    
    public int StudentId { get; set; }
    public Student Student { get; set; }
}