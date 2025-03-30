using Microsoft.EntityFrameworkCore;
using UniversityCatalog.Core.DTOs.Courses;
using UniversityCatalog.Core.Entities;
using UniversityCatalog.Core.Interfaces;
using UniversityCatalog.Core.Interfaces.Services;
using UniversityCatalog.Infrastructure.Repositories;
using UniversityCatalog.Infrastructure.Specifications;
using UniversityCatalog.Infrastructure.Specifications.CourseSpecifications;
using UniversityCatalog.Infrastructure.Specifications.TeacherSpecifications;

namespace UniversityCatalog.Infrastructure.Services;

public class CourseService(IGenericRepository<Course> courseRepository, IGenericRepository<Teacher> teacherRepository) : ICourseService
{
    private readonly IGenericRepository<Course> _courseRepository = courseRepository;
    private readonly IGenericRepository<Teacher> _teacherRepository = teacherRepository;
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
    public async Task<Course> CreateCourseAsync(CourseCreateDto courseDto)
    {
        
        var addedCourse = new Course
        {
            Name = courseDto.Name,
            LecturerId = courseDto.LecturerId,
            Lecturer = await _teacherRepository.GetByIdAsync(courseDto.LecturerId),
            CourseTeachers = 
                courseDto.TeachersIds.Select(teacherId => new CourseTeacher{TeacherId = teacherId}).ToList(),
            CourseStudents = 
                courseDto.StudentsIds.Select(studentId => new CourseStudent{StudentId = studentId}).ToList(),
            Grades = 
                courseDto.GradeIds.Select(studentId => new Grade{StudentId = studentId}).ToList()
        };
        await _courseRepository.AddAsync(addedCourse);
        return addedCourse;
    }
    public async Task<Course> UpdateCourseAsync(CourseUpdateDto courseDto)
    {
        if (courseDto == null)
            throw new KeyNotFoundException("Course not found!");
        var updateCourse = await _courseRepository.GetByIdAsync(courseDto.Id);
        updateCourse.Id = courseDto.Id;
        updateCourse.Name = courseDto.Name;
        updateCourse.LecturerId = courseDto.LecturerId;
        updateCourse.Lecturer = await _teacherRepository.GetByIdAsync(courseDto.LecturerId);
        updateCourse.CourseTeachers = 
            courseDto.TeachersIds.Select(teacherId => new CourseTeacher{TeacherId = teacherId,CourseId = updateCourse.Id}).ToList();
        updateCourse.CourseStudents = 
            courseDto.StudentsIds.Select(studentId => new CourseStudent{StudentId = studentId,CourseId = updateCourse.Id}).ToList();
        updateCourse.Grades = 
            courseDto.GradeIds.Select(studentId => new Grade{StudentId = studentId,CourseId = updateCourse.Id}).ToList();
        await _courseRepository.UpdateAsync(updateCourse);
        return updateCourse;
    }
    public async Task DeleteCoursesAsync(int id)
    {
        await _courseRepository.DeleteAsync(id);
    }
}