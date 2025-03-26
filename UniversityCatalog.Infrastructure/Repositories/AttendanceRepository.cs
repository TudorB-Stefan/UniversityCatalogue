using API.Models;
using Microsoft.EntityFrameworkCore;
using UniversityCatalog.Core.Interfaces;
using UniversityCatalog.Infrastructure.Specifications;

namespace UniversityCatalog.Infrastructure.Repositories;

public class AttendanceRepository(DbContext context) : IGenericM2MRepository<Attendance>
{
    protected readonly DbContext _context=context;
    protected readonly DbSet<Attendance> _dbSet=context.Set<Attendance>();
    public async Task<List<Attendance>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }
    public async Task<Attendance> GetByIdAsync(int studentId,int courseId)
    {
        var temp = await _dbSet.FindAsync(studentId,courseId);
        if (temp is null)
            throw new KeyNotFoundException("Attendance record not found.");
        return temp;
    }
    public async Task AddAsync(Attendance attendance)
    {
        if (attendance is null)
            throw new KeyNotFoundException("Invalid Attendance");
        await _dbSet.AddAsync(attendance);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Attendance attendance)
    {
        var temp = await _dbSet.FindAsync(attendance.StudentId,attendance.CourseId);
        if(temp is null)
            throw new KeyNotFoundException("Attendance record not found.");
        _dbSet.Entry(temp).CurrentValues.SetValues(attendance);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var temp = await _dbSet.FindAsync(id);
        if (temp is null)
            throw new KeyNotFoundException("Attendance record not found.");
        _dbSet.Remove(temp);
        await _context.SaveChangesAsync();
    }
    public async Task<List<Attendance>> GetListBySpecificationAsync(ISpecification<Attendance> specification)
    {
        var query = SpecificationEvaluator<Attendance>.GetQuery(_dbSet.AsQueryable(), specification);
        return await query.ToListAsync();
    }
}