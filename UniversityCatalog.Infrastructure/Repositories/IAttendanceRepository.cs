using API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace UniversityCatalog.Infrastructure.Repositories;

public class AttendanceRepository(DbContext context) : IRepositoryComp<Attendance>
{
    protected readonly DbContext _context=context;
    protected readonly DbSet<Attendance> _dbSet=context.Set<Attendance>();
    public async Task<IEnumerable<Attendance>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<Attendance> GetByIdAsync(int studentId,int courseId)
    {
        var foundAttendace = await _dbSet.FindAsync(studentId,courseId);
        if (foundAttendace is null)
            throw new KeyNotFoundException("Attendance record not found.");
        return foundAttendace;
    }
    public async Task<Attendance> AddAsync(Attendance attendance)
    {
        await _dbSet.AddAsync(attendance);
        await _context.SaveChangesAsync();
        return attendance;
    }

    public async Task UpdateAsync(Attendance attendance)
    {
        var toBeChange = await _dbSet.FindAsync(attendance.StudentId,attendance.CourseId);
        if(toBeChange is null)
            throw new KeyNotFoundException("Attendance record not found.");
        _dbSet.Entry(toBeChange).CurrentValues.SetValues(attendance);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var toBeDeleted = await _dbSet.FindAsync(id);
        if (toBeDeleted is null)
            throw new KeyNotFoundException("Attendance record not found.");
        _dbSet.Remove(toBeDeleted);
        await _context.SaveChangesAsync();
    }
}