using API.Models;

namespace UniversityCatalog.Infrastructure.Specifications.GradeSpecification;

public class GetGradesWithStudentIdSpecification : BaseSpecification<Grade>
{
    public GetGradesWithStudentIdSpecification(int studentId)
        : base(g => g.StudentId == studentId)
    {
        AddInclude(g => g.Student);
        ApplyOrderByDescending(g => g.Date);
    }
}