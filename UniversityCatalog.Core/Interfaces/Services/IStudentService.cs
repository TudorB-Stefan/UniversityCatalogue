using API.Models;
using UniversityCatalog.API.DTOs.Students;

namespace UniversityCatalog.Core.Interfaces.Services;

public interface IStudentService
{
    Task<IReadOnlyList<Student>> GetAllStudentsAsync();
    Task<IReadOnlyList<Student>> GetStudentsByCourseIdAsync(int courseId);
    Task<Student> GetStudentsByIdAsync(int id);  
    Task<Student> CreateStudentAsync(StudentCreateDto student);  
    Task<Student> UpdateStudentAsync(StudentUpdateDto student);
    Task DeleteStudentsAsync(int id);
}