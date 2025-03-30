using UniversityCatalog.Core.DTOs.Attendances;
using UniversityCatalog.Core.DTOs.Attendances;
using UniversityCatalog.Core.Entities;
using UniversityCatalog.Core.Interfaces;
using UniversityCatalog.Core.Interfaces.Services;
using UniversityCatalog.Infrastructure.Specifications.AttendanceSpecifications;

namespace UniversityCatalog.Infrastructure.Services;

public class AttendanceService(IGenericM2MRepository<Attendance> attendanceRepository,IGenericRepository<Student> studentRepository,IGenericRepository<Course> courseRepository) : IAttendanceService
{
    private readonly IGenericM2MRepository<Attendance> _attendanceRepository = attendanceRepository;
    private readonly IGenericRepository<Student> _studentRepository = studentRepository;
    private readonly IGenericRepository<Course> _courseRepository = courseRepository;
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
    public async Task<Attendance> CreateAttendanceAsync(AttendanceCreateDto attendanceDto)
    {
        var addedAttendance = new Attendance
        {
            Date = attendanceDto.Date,
            IsPresent = attendanceDto.IsPresent,
            StudentId = attendanceDto.StudentId,
            Student = await _studentRepository.GetByIdAsync(attendanceDto.StudentId),
            CourseId = attendanceDto.CourseId,
            Course = await _courseRepository.GetByIdAsync(attendanceDto.CourseId),
            CourseType = attendanceDto.CourseType
        };
        await _attendanceRepository.AddAsync(addedAttendance);
        return addedAttendance;
    }
    public async Task<Attendance> UpdateAttendanceAsync(AttendanceUpdateDto attendanceDto)
    {
        if (attendanceDto == null)
            throw new KeyNotFoundException("Course not found!");
        var updateAttendance = await _attendanceRepository.GetByIdAsync(attendanceDto.CourseId,attendanceDto.StudentId);
        updateAttendance.Date = attendanceDto.Date;
        updateAttendance.IsPresent = attendanceDto.IsPresent;
        updateAttendance.StudentId = attendanceDto.StudentId;
        updateAttendance.Student = await _studentRepository.GetByIdAsync(attendanceDto.StudentId);
        updateAttendance.CourseId = attendanceDto.CourseId;
        updateAttendance.Course = await _courseRepository.GetByIdAsync(attendanceDto.CourseId);
        updateAttendance.CourseType = attendanceDto.CourseType;
        await _attendanceRepository.UpdateAsync(updateAttendance);
        return updateAttendance;
    }
    public async Task DeleteAttendanceAsync(int id)
    {
        await _attendanceRepository.DeleteAsync(id);
    }
}