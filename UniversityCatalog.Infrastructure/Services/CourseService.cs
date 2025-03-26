using API.Models;
using UniversityCatalog.Core.Interfaces;
using UniversityCatalog.Core.Interfaces.Services;
using UniversityCatalog.Infrastructure.Specifications.CourseSpecifications;

namespace UniversityCatalog.Infrastructure.Services;

public class CourseService(IGenericRepository<Course> courseRepository) : ICourseService
{
    private readonly IGenericRepository<Course> _courseRepository = courseRepository;
    public async Task<IReadOnlyList<Course>> GetAllCoursesAsync()
    {
        return await _courseRepository.GetAllAsync();
    }
    public async Task<IReadOnlyList<Course>> GetCoursesByTeacherIdAsync(int teacherId)
    {
        var spec = new GetCourseWithTeacherIdSpecification(teacherId);
        return await _courseRepository.GetListBySpecificationAsync(spec);
    }
    public async Task<IReadOnlyList<Course>> GetCoursesByStudenteIdAsync(int studentId)
    {
        var spec = new GetCourseWithStudentIdSpecification(studentId);
        return await _courseRepository.GetListBySpecificationAsync(spec);
    }
    public async Task<Course> GetCoursesByIdAsync(int id)
    {
        return await _courseRepository.GetByIdAsync(id);
    }
    public async Task<Course> CreateCourseAsync(Course course)
    {
        await _courseRepository.AddAsync(course);
        return course;
    }
    public async Task<Course> UpdateCourseAsync(Course course)
    {
        await _courseRepository.UpdateAsync(course);
        return course;
    }
    public async Task DeleteCoursesAsync(int id)
    {
        await _courseRepository.DeleteAsync(id);
    }
}