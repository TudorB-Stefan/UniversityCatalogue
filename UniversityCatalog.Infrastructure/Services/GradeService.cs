using API.Models;
using UniversityCatalog.Core.Interfaces;
using UniversityCatalog.Core.Interfaces.Services;
using UniversityCatalog.Infrastructure.Specifications.GradeSpecification;

namespace UniversityCatalog.Infrastructure.Services;

public class GradeService(IGenericM2MRepository<Grade> gradeRepository) : IGradeService
{
    private readonly IGenericM2MRepository<Grade> _gradeRepository = gradeRepository;
    public async Task<IReadOnlyList<Grade>> GetAllGradesAsync()
    {
        return await _gradeRepository.GetAllAsync();
    }
    public async Task<IReadOnlyList<Grade>> GetGradesByStudentIdAsync(int studentId)
    {
        var spec = new GetGradesWithStudentIdSpecification(studentId);
        return await _gradeRepository.GetListBySpecificationAsync(spec);
    }
    public async Task<IReadOnlyList<Grade>> GetGradeByCourseIdAsync(int coursetId)
    {
        var spec = new GetGradesWithCourseIdSpecification(coursetId);
        return await _gradeRepository.GetListBySpecificationAsync(spec);
    }
    public async Task<Grade> GetGradesByIdAsync(int studentId,int courseId)
    {
        return await _gradeRepository.GetByIdAsync(studentId,courseId);
    }
    public async Task<Grade> CreateGradeAsync(Grade grade)
    {
        await _gradeRepository.AddAsync(grade);
        return grade;
    }
    public async Task<Grade> UpdateGradeAsync(Grade grade)
    {
        await _gradeRepository.UpdateAsync(grade);
        return grade;
    }
    public async Task DeleteGradeAsync(int id)
    {
        await _gradeRepository.DeleteAsync(id);
    }
}