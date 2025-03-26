using API.Models;

namespace UniversityCatalog.Infrastructure.Specifications.StudentSpecifications;

public class GetStudentsWithCourseIdSpecification : BaseSpecification<Student>
{
    public GetStudentsWithCourseIdSpecification(int courseId)
        : base(s => s.CourseStudents.Any(cs => cs.CourseId == courseId))
    {
        AddInclude(s => s.CourseStudents);
        AddInclude(s => s.CourseStudents.Select(cs => cs.Course));
        ApplyOrderBy(s => s.Id);
    }
}