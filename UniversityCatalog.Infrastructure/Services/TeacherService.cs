using Microsoft.AspNetCore.Identity;
using UniversityCatalog.Core.DTOs.Teachers;
using UniversityCatalog.Core.Entities;
using UniversityCatalog.Core.Interfaces;
using UniversityCatalog.Core.Interfaces.Services;
using UniversityCatalog.Infrastructure.Specifications.TeacherSpecifications;

namespace UniversityCatalog.Infrastructure.Services;

public class TeacherService(IGenericRepository<Teacher> teacherRepository,IGenericRepository<Role> roleRepository) : ITeacherService
{
    private readonly IGenericRepository<Teacher> _teacherRepository=teacherRepository;
    private readonly IGenericRepository<Role> _roleRepository=roleRepository;

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
    public async Task<Teacher> CreateTeacherAsync(TeacherCreateDto teacherDto)
    {
        var addedTeacher = new Teacher
        {
            FirstName = teacherDto.FirstName,
            LastName = teacherDto.LastName,
            Email = teacherDto.Email,
            PhoneNumber = teacherDto.PhoneNumber,
            RoleId = teacherDto.RoleId,
            Role = await _roleRepository.GetByIdAsync(teacherDto.RoleId),
            CourseTeachers = 
                teacherDto.CourseIds.Select(courseId => new CourseTeacher{CourseId = courseId}).ToList()
        };
        await _teacherRepository.AddAsync(addedTeacher);
        return addedTeacher;
    }
    public async Task<Teacher> UpdateTeacherAsync(TeacherUpdateDto teacherDto)
    {
        if (teacherDto == null)
            throw new KeyNotFoundException("Teacher not found!");
        var updateTeacher = await _teacherRepository.GetByIdAsync(teacherDto.Id);

        updateTeacher.FirstName = teacherDto.FirstName;
        updateTeacher.LastName = teacherDto.LastName;
        updateTeacher.Email = teacherDto.Email;
        updateTeacher.PhoneNumber = teacherDto.PhoneNumber;
        updateTeacher.RoleId = teacherDto.RoleId;
        updateTeacher.Role =  await _roleRepository.GetByIdAsync(teacherDto.RoleId);
        updateTeacher.CourseTeachers = 
            teacherDto.CourseIds.Select(courseId => new CourseTeacher{CourseId = courseId,TeacherId = updateTeacher.Id}).ToList();
        
        await _teacherRepository.UpdateAsync(updateTeacher);
        return updateTeacher;
    }
    public async Task DeleteTeacherAsync(int id)
    {
        await _teacherRepository.DeleteAsync(id);
    }
}