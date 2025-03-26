using API.Models;

namespace UniversityCatalog.Infrastructure.Specifications.TeacherSpecifications;

public class GetTeachersWithCourseIdSpecification : BaseSpecification<Teacher>
{
    public GetTeachersWithCourseIdSpecification(int courseId)
        : base(t => t.CourseTeachers.Any(ct => ct.CourseId == courseId))
    {
        AddInclude(t => t.CourseTeachers);
        AddInclude(t => t.CourseTeachers.Select(ct => ct.CourseId));
        ApplyOrderBy(t => t.Id);
    }
}