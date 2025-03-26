using API.Models;
using Microsoft.EntityFrameworkCore;
using UniversityCatalog.Core.Interfaces;
using UniversityCatalog.Infrastructure.Specifications;

namespace UniversityCatalog.Infrastructure.Repositories;

public class GradeRepository(DbContext context) : IGenericM2MRepository<Grade>
{
    protected readonly DbContext _context = context;
    protected readonly DbSet<Grade> _dbSet=context.Set<Grade>();

    public async Task<List<Grade>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<Grade> GetByIdAsync(int studentId,int courseId)
    {
        var temp = await _dbSet.FindAsync(studentId,courseId);
        if (temp is null)
            throw new KeyNotFoundException("Grade record not found");
        return temp;
    }

    public async Task AddAsync(Grade grade)
    {
        if (grade is null)
            throw new KeyNotFoundException("Invalid Grade");
        await _dbSet.AddAsync(grade);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Grade grade)
    {
        var temp = await _dbSet.FindAsync(grade.Id);
        if (temp is null)
            throw new KeyNotFoundException("Grade record not found");
        _dbSet.Entry(temp).CurrentValues.SetValues(grade);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var temp = await _dbSet.FindAsync(id);
        if (temp is null)
            throw new KeyNotFoundException("Grade record not found");
        _dbSet.Remove(temp);
        await _context.SaveChangesAsync();
    }
    public async Task<List<Grade>> GetListBySpecificationAsync(ISpecification<Grade> specification)
    {
        var query = SpecificationEvaluator<Grade>.GetQuery(_dbSet.AsQueryable(), specification);
        return await query.ToListAsync();
    }
}