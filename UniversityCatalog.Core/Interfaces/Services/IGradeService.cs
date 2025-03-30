using UniversityCatalog.Core.DTOs.Grades;
using UniversityCatalog.Core.Entities;

namespace UniversityCatalog.Core.Interfaces.Services;

public interface IGradeService
{
    Task<IReadOnlyList<Grade>> GetAllGradesAsync();
    Task<IReadOnlyList<Grade>> GetGradesByStudentIdAsync(int studentId);
    Task<IReadOnlyList<Grade>> GetGradeByCourseIdAsync(int courseId);
    Task<Grade> GetGradesByIdAsync(int studentId,int courseId);
    Task<Grade> CreateGradeAsync(GradeCreateDto gradeDto);
    Task<Grade> UpdateGradeAsync(GradeUpdateDto gradeDto);
    Task DeleteGradeAsync(int id);
    
}