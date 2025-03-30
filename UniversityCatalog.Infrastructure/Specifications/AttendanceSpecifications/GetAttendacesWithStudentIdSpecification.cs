using UniversityCatalog.Core.Entities;

namespace UniversityCatalog.Infrastructure.Specifications.AttendanceSpecifications;

public class GetAttendacesWithStudentIdSpecification : BaseSpecification<Attendance>
{
    public GetAttendacesWithStudentIdSpecification(int studentId)
        : base(a => a.StudentId == studentId)
    {
        AddInclude(a => a.Student);
        ApplyOrderByDescending(a => a.Date);
    }
}