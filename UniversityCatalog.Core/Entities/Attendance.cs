﻿using UniversityCatalog.API.DTOs.Courses;
using UniversityCatalog.API.DTOs.Students;

namespace API.Models;

public class Attendance
{
    public DateTime Date { get; set; }
    public bool IsPresent { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; }
    public string CourseType { get; set; }
}