using UniversityCatalog.Core.Entities;

namespace UniversityCatalog.Infrastructure.Specifications.GradeSpecification;

public class GetGradesWithCourseIdSpecification : BaseSpecification<Grade>
{
    public GetGradesWithCourseIdSpecification(int courseId)
        : base(g => g.CourseId == courseId)
    {
        AddInclude(g => g.Course);
        ApplyOrderByDescending(g => g.Date);
    }
}