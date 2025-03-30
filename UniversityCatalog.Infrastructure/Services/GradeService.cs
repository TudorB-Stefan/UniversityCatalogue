using UniversityCatalog.Core.DTOs.Grades;
using UniversityCatalog.Core.Entities;
using UniversityCatalog.Core.Interfaces;
using UniversityCatalog.Core.Interfaces.Services;
using UniversityCatalog.Infrastructure.Specifications.GradeSpecification;

namespace UniversityCatalog.Infrastructure.Services;

public class GradeService(IGenericM2MRepository<Grade> gradeRepository,IGenericRepository<Course> courseRepository,IGenericRepository<Student> studentRepository) : IGradeService
{
    private readonly IGenericM2MRepository<Grade> _gradeRepository = gradeRepository;
    private readonly IGenericRepository<Course> _courseRepository = courseRepository;
    private readonly IGenericRepository<Student> _studentRepository = studentRepository;
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
    public async Task<Grade> CreateGradeAsync(GradeCreateDto gradeDto)
    {
        var addedGrade = new Grade
        {
            Date = gradeDto.Date,
            Value = gradeDto.Value,
            GradeType = gradeDto.GradeType,
            CourseId = gradeDto.CourseId,
            Course = await _courseRepository.GetByIdAsync(gradeDto.CourseId),
            StudentId = gradeDto.StudentId,
            Student = await _studentRepository.GetByIdAsync(gradeDto.StudentId)
        };
        await _gradeRepository.AddAsync(addedGrade);
        return addedGrade;
    }
    public async Task<Grade> UpdateGradeAsync(GradeUpdateDto gradeDto)
    {
        if (gradeDto == null)
            throw new KeyNotFoundException("Course not found!");
        var updateGrade = await _gradeRepository.GetByIdAsync(gradeDto.CourseId,gradeDto.StudentId);
        updateGrade.Date = gradeDto.Date;
        updateGrade.Value = gradeDto.Value;
        updateGrade.GradeType = gradeDto.GradeType;
        updateGrade.CourseId = gradeDto.CourseId;
        updateGrade.Course = await _courseRepository.GetByIdAsync(gradeDto.CourseId);
        updateGrade.StudentId = gradeDto.StudentId;
        updateGrade.Student = await _studentRepository.GetByIdAsync(gradeDto.StudentId);
        await _gradeRepository.UpdateAsync(updateGrade);
        return updateGrade;
    }
    public async Task DeleteGradeAsync(int id)
    {
        await _gradeRepository.DeleteAsync(id);
    }
}