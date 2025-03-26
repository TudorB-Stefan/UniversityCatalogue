using API.Models;
using Microsoft.EntityFrameworkCore;
using UniversityCatalog.Core.Interfaces;
using UniversityCatalog.Infrastructure.Specifications;

namespace UniversityCatalog.Infrastructure.Repositories;

public class StudentRepository(DbContext context):IGenericRepository<Student>
{
    protected readonly DbContext _context = context;
    protected readonly DbSet<Student> _dbSet = context.Set<Student>();

    public async Task<List<Student>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<Student> GetByIdAsync(int id)
    {
        var temp = await _dbSet.FindAsync(id);
        if (temp == null)
            throw new KeyNotFoundException("Student record not found");
        return temp;
    }

    public async Task AddAsync(Student student)
    {
        if (student == null)
            throw new KeyNotFoundException("Invalid Student");
        await _dbSet.AddAsync(student);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Student student)
    {
        var temp = await _dbSet.FindAsync(student.Id);
        if (temp == null)
            throw new KeyNotFoundException("Student record not found");
        _dbSet.Entry(temp).CurrentValues.SetValues(student);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var temp = await _dbSet.FindAsync(id);
        if (temp == null)
            throw new KeyNotFoundException("Student record not found");
        _dbSet.Remove(temp);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Student>> GetListBySpecificationAsync(ISpecification<Student> specification)
    {
        var query = SpecificationEvaluator<Student>.GetQuery(_dbSet.AsQueryable(), specification);
        return await query.ToListAsync();
    }
}