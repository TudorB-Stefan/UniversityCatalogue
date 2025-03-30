﻿namespace UniversityCatalog.Core.Entities;

public class CourseTeacher
{
    public int CourseId { get; set; }
    public Course Course { get; set; }

    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }
    
    public TeacherPositionType TeacherPosition { get; set; }
}

public enum TeacherPositionType
{
    Seminar,
    Lab
}