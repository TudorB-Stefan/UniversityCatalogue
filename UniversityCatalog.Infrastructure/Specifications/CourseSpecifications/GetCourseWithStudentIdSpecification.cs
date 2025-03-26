using API.Models;

namespace UniversityCatalog.Infrastructure.Specifications.CourseSpecifications;

public class GetCourseWithStudentIdSpecification : BaseSpecification<Course>
{
    public GetCourseWithStudentIdSpecification(int studentId)
        : base(c => c.CourseStudents.Any(cs => cs.StudentId == studentId))
    {
        AddInclude(c => c.CourseStudents);
        AddInclude(c => c.CourseStudents.Select(cs => cs.Student));
        ApplyOrderBy(c => c.Id);
    }
}