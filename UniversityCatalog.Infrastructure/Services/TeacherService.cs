using API.Models;
using UniversityCatalog.Core.Interfaces;
using UniversityCatalog.Core.Interfaces.Services;
using UniversityCatalog.Infrastructure.Specifications.TeacherSpecifications;

namespace UniversityCatalog.Infrastructure.Services;

public class TeacherService(IGenericRepository<Teacher> teacherRepository) : ITeacherService
{
    private readonly IGenericRepository<Teacher> _teacherRepository=teacherRepository;

    public async Task<IReadOnlyList<Teacher>> GetAllTeachersAsync()
    {
        return await _teacherRepository.GetAllAsync();
    }
    public async Task<IReadOnlyList<Teacher>> GetTeachersByCourseIdAsync(int courseId)
    {
        var spec = new GetTeachersWithCourseIdSpecification(courseId);
        return await _teacherRepository.GetListBySpecificationAsync(spec);
    }
    public async Task<Teacher> GetTeachersByIdAsync(int id)
    {
        return await _teacherRepository.GetByIdAsync(id);
    }
    public async Task<Teacher> CreateTeacherAsync(Teacher teacher)
    {
        await _teacherRepository.AddAsync(teacher);
        return teacher;
    }
    public async Task<Teacher> UpdateTeacherAsync(Teacher teacher)
    {
        await _teacherRepository.UpdateAsync(teacher);
        return teacher;
    }
    public async Task DeleteTeacherAsync(int id)
    {
        await _teacherRepository.DeleteAsync(id);
    }
}