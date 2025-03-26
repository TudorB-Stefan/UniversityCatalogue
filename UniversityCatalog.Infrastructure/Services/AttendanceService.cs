using API.Models;
using UniversityCatalog.Core.Interfaces;
using UniversityCatalog.Core.Interfaces.Services;
using UniversityCatalog.Infrastructure.Specifications.AttendanceSpecifications;

namespace UniversityCatalog.Infrastructure.Services;

public class AttendanceService(IGenericM2MRepository<Attendance> attendanceRepository) : IAttendanceService
{
    private readonly IGenericM2MRepository<Attendance> _attendanceRepository = attendanceRepository;
    public async Task<IReadOnlyList<Attendance>> GetAllAttendancesAsync()
    {
        return await _attendanceRepository.GetAllAsync();
    }

    public async Task<IReadOnlyList<Attendance>> GetAttendancesByStudentIdAsync(int studentId)
    {
        var spec = new GetAttendacesWithStudentIdSpecification(studentId);
        return await _attendanceRepository.GetListBySpecificationAsync(spec);
    }

    public async Task<IReadOnlyList<Attendance>> GetAttendancesByCourseIdAsync(int courseId)
    {
        var spec = new GetAttendacesWithCourseIdSpecification(courseId);
        return await _attendanceRepository.GetListBySpecificationAsync(spec);
    }
    public async Task<Attendance> GetAttendanceByIdAsync(int studentId,int courseId)
    {
        return await _attendanceRepository.GetByIdAsync(studentId,courseId);
    }
    public async Task<Attendance> CreateAttendanceAsync(Attendance attendance)
    {
        await _attendanceRepository.AddAsync(attendance);
        return attendance;
    }
    public async Task<Attendance> UpdateAttendanceAsync(Attendance attendance)
    {
        await _attendanceRepository.UpdateAsync(attendance);
        return attendance;
    }
    public async Task DeleteAttendanceAsync(int id)
    {
        await _attendanceRepository.DeleteAsync(id);
    }
}