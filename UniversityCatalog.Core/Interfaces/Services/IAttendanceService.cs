using UniversityCatalog.Core.DTOs.Attendances;
using UniversityCatalog.Core.DTOs.Attendances;
using UniversityCatalog.Core.Entities;

namespace UniversityCatalog.Core.Interfaces.Services;

public interface IAttendanceService
{
    Task<IReadOnlyList<Attendance>> GetAllAttendancesAsync();
    Task<IReadOnlyList<Attendance>> GetAttendancesByStudentIdAsync(int studentId);
    Task<IReadOnlyList<Attendance>> GetAttendancesByCourseIdAsync(int courseId);
    Task<Attendance> GetAttendanceByIdAsync(int studentId,int courseId);  
    Task<Attendance> CreateAttendanceAsync(AttendanceCreateDto attendanceDto);  
    Task<Attendance> UpdateAttendanceAsync(AttendanceUpdateDto attendanceDto);
    Task DeleteAttendanceAsync(int id);
}