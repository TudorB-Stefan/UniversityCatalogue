using UniversityCatalog.Core.DTOs.Courses;
using UniversityCatalog.Core.Entities;

namespace UniversityCatalog.Core.Interfaces.Services;

public interface ICourseService
{
    Task<IReadOnlyList<Course>> GetAllCoursesAsync();
    Task<IReadOnlyList<Course>> GetCoursesByTeacherIdAsync(int teacherId);
    Task<IReadOnlyList<Course>> GetCoursesByStudenteIdAsync(int studentId);
    Task<Course> GetCoursesByIdAsync(int id);  
    Task<Course> CreateCourseAsync(CourseCreateDto course);  
    Task<Course> UpdateCourseAsync(CourseUpdateDto course);
    Task DeleteCoursesAsync(int id);
}