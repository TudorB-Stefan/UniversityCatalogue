﻿namespace UniversityCatalog.Core.DTOs.Teachers;

public class TeacherUpdateDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public int RoleId { get; set; }
    public List<int> CourseIds { get; set; }
}