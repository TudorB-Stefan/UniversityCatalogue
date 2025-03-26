using API.Models;

namespace UniversityCatalog.Core.Interfaces.Services;

public interface IGradeService
{
    Task<IReadOnlyList<Grade>> GetAllGradesAsync();
    Task<IReadOnlyList<Grade>> GetGradesByStudentIdAsync(int studentId);
    Task<IReadOnlyList<Grade>> GetGradeByCourseIdAsync(int courseId);
    Task<Grade> GetGradesByIdAsync(int studentId,int courseId);
    Task<Grade> CreateGradeAsync(Grade grade);
    Task<Grade> UpdateGradeAsync(Grade grade);
    Task DeleteGradeAsync(int id);
    
}