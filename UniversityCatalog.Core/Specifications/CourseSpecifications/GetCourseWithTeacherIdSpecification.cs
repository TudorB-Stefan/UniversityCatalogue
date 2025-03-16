using API.Models;
namespace UniversityCatalog.Infrastructure.Specifications.CourseSpecifications;

public class GetCourseWithTeacherIdSpecification : BaseSpecification<Course>
{
    public GetCourseWithTeacherIdSpecification(int teacherId)
        : base(c => c.CourseTeachers.Any(ct => ct.TeacherId == teacherId))
    {
        AddInclude(c => c.CourseTeachers);
        AddInclude(c => c.CourseTeachers.Select(ct => ct.Teacher));
    }
}