using API.Models;

namespace UniversityCatalog.Core.Interfaces.Services;

public interface ICourseService
{
    Task<IReadOnlyList<Course>> GetAllCoursesAsync();
    Task<IReadOnlyList<Course>> GetCoursesByTeacherIdAsync(int teacherId);
    Task<IReadOnlyList<Course>> GetCoursesByStudenteIdAsync(int studentId);
    Task<Course> GetCoursesByIdAsync(int id);  
    Task<Course> CreateCourseAsync(Course course);  
    Task<Course> UpdateCourseAsync(Course course);
    Task DeleteCoursesAsync(int id);
}