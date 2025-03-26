using API.Models;

namespace UniversityCatalog.Core.Interfaces.Services;

public interface IAttendanceService
{
    Task<IReadOnlyList<Attendance>> GetAllAttendancesAsync();
    Task<IReadOnlyList<Attendance>> GetAttendancesByStudentIdAsync(int studentId);
    Task<IReadOnlyList<Attendance>> GetAttendancesByCourseIdAsync(int courseId);
    Task<Attendance> GetAttendanceByIdAsync(int studentId,int courseId);  
    Task<Attendance> CreateAttendanceAsync(Attendance attendance);  
    Task<Attendance> UpdateAttendanceAsync(Attendance attendance);
    Task DeleteAttendanceAsync(int id);
}