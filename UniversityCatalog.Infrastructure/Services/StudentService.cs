using UniversityCatalog.Core.DTOs.Students;
using UniversityCatalog.Core.Entities;
using UniversityCatalog.Core.Interfaces;
using UniversityCatalog.Core.Interfaces.Services;
using UniversityCatalog.Infrastructure.Specifications.StudentSpecifications;

namespace UniversityCatalog.Infrastructure.Services;

public class StudentService(IGenericRepository<Student> studentRepository) : IStudentService
{
    private readonly IGenericRepository<Student> _studentRepository = studentRepository;
    public async Task<IReadOnlyList<Student>> GetAllStudentsAsync()
    {
        return await _studentRepository.GetAllAsync();
    }
    public async Task<IReadOnlyList<Student>> GetStudentsByCourseIdAsync(int courseId)
    {
        var spec = new GetStudentsWithCourseIdSpecification(courseId);
        return await _studentRepository.GetListBySpecificationAsync(spec);
    }
    public async Task<Student> GetStudentsByIdAsync(int id)
    {
        return await _studentRepository.GetByIdAsync(id);
    }
    public async Task<Student> CreateStudentAsync(StudentCreateDto studentDto)
    {
        var addedStudent = new Student
        {
            FirstName = studentDto.FirstName,
            LastName = studentDto.LastName,
            Email = studentDto.Email,
            PhoneNumber = studentDto.PhoneNumber,
            CurrentYear = studentDto.CurrentYear,
            // LastYear = studentDto.LastYear,
            CourseStudents = 
                studentDto.CourseIds.Select(courseId => new CourseStudent{CourseId = courseId}).ToList(),
            Grades = 
                studentDto.GradeIds.Select(courseId => new Grade{CourseId = courseId}).ToList(),
            Attendances = 
                studentDto.GradeIds.Select(courseId => new Attendance{CourseId = courseId}).ToList()
        };
        await _studentRepository.AddAsync(addedStudent);
        return addedStudent;
    }
    public async Task<Student> UpdateStudentAsync(StudentUpdateDto studentDto)
    {
        if (studentDto == null)
            throw new KeyNotFoundException("Student not found!");
        var updateStudent = await _studentRepository.GetByIdAsync(studentDto.Id);

        updateStudent.Id = studentDto.Id;
        updateStudent.FirstName = studentDto.FirstName;
        updateStudent.LastName = studentDto.LastName;
        updateStudent.Email = studentDto.Email;
        updateStudent.PhoneNumber = studentDto.PhoneNumber;
        updateStudent.CurrentYear = studentDto.CurrentYear;
        // updateStudent.LastYear = studentDto.LastYear;
        updateStudent.CourseStudents =
            studentDto.CourseIds.Select(courseId => new CourseStudent { CourseId = courseId,StudentId = updateStudent.Id}).ToList();
        updateStudent.Grades = 
            studentDto.GradeIds.Select(courseId => new Grade { CourseId = courseId,StudentId = updateStudent.Id }).ToList();
        updateStudent.Attendances =
            studentDto.GradeIds.Select(courseId => new Attendance { CourseId = courseId,StudentId = updateStudent.Id }).ToList();
        
        await _studentRepository.UpdateAsync(updateStudent);
        return updateStudent;
    }
    public async Task DeleteStudentsAsync(int id)
    {
        await _studentRepository.DeleteAsync(id);
    }
}