using UniversityCatalog.Core.DTOs.Teachers;
using UniversityCatalog.Core.Entities;

namespace UniversityCatalog.Core.Interfaces.Services;

public interface ITeacherService
{
    Task<IReadOnlyList<Teacher>> GetAllTeachersAsync();
    Task<IReadOnlyList<Teacher>> GetTeachersByCourseIdAsync(int courseId);
    Task<Teacher> GetTeachersByIdAsync(int id);
    Task<Teacher> CreateTeacherAsync(TeacherCreateDto teacherDto);
    Task<Teacher> UpdateTeacherAsync(TeacherUpdateDto teacherDto);
    Task DeleteTeacherAsync(int id);
}