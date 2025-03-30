using UniversityCatalog.Core.Entities;

namespace UniversityCatalog.Infrastructure.Specifications.AttendanceSpecifications;

public class GetAttendacesWithCourseIdSpecification : BaseSpecification<Attendance>
{
    public GetAttendacesWithCourseIdSpecification(int courseId)
        : base(a => a.CourseId == courseId)
    {
        AddInclude(a => a.Course);
        ApplyOrderByDescending(a => a.Date);
    }
}