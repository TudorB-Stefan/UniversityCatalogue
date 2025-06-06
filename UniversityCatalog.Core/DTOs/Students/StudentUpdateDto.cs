﻿namespace UniversityCatalog.Core.DTOs.Students;

public class StudentUpdateDto
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public int CurrentYear { get; set; }
    // public DateTime LastYear { get; set; }
    
    public List<int> CourseIds { get; set; }
    public List<int> GradeIds { get; set; }
    public List<int> AttendancesIds { get; set; }
}