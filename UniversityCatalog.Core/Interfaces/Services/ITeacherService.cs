using API.Models;

namespace UniversityCatalog.Core.Interfaces.Services;

public interface ITeacherService
{
    Task<IReadOnlyList<Teacher>> GetAllTeachersAsync();
    Task<IReadOnlyList<Teacher>> GetTeachersByCourseIdAsync(int courseId);
    Task<Teacher> GetTeachersByIdAsync(int id);
    Task<Teacher> CreateTeacherAsync(Teacher teacher);
    Task<Teacher> UpdateTeacherAsync(Teacher teacher);
    Task DeleteTeacherAsync(int id);
}