namespace API.Models;

public class Grade
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public decimal Value { get; set; }
    public GradeType GradeType { get; set; }
    
    public int CourseId { get; set; }
    public Course Course { get; set; }
    
    public int StudentId { get; set; }
    public Student Student { get; set; }
}
public enum GradeType{
    Course,
    Seminary,
    Lab
}