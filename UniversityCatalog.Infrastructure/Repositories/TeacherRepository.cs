using Microsoft.EntityFrameworkCore;
using UniversityCatalog.Core.Entities;
using UniversityCatalog.Core.Interfaces;
using UniversityCatalog.Infrastructure.Data;
using UniversityCatalog.Infrastructure.Specifications;
using UniversityCatalog.Infrastructure.Specifications.TeacherSpecifications;

namespace UniversityCatalog.Infrastructure.Repositories;

public class TeacherRepository(ApplicationDbContext context):IGenericRepository<Teacher>
{
    
    protected readonly DbContext _context = context;
    protected readonly DbSet<Teacher> _dbSet = context.Set<Teacher>();

    public async Task<List<Teacher>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<Teacher> GetByIdAsync(int id)
    {
        var temp = await _dbSet.FindAsync(id);
        if (temp == null)
            throw new KeyNotFoundException("Teacher record not found");
        return temp;
    }
    public async Task AddAsync(Teacher teacher)
    {
        if (teacher == null)
            throw new KeyNotFoundException("Invalid Teacher");
        await _dbSet.AddAsync(teacher);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateAsync(Teacher teacher)
    {
        var temp = await _dbSet.FindAsync(teacher.Id);
        if (temp == null)
            throw new KeyNotFoundException("Teacher record not found");
        _dbSet.Entry(temp).CurrentValues.SetValues(teacher);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        var temp = await _dbSet.FindAsync(id);
        if (temp == null)
            throw new KeyNotFoundException("Teacher record not found");
        _dbSet.Remove(temp);
        await _context.SaveChangesAsync();
    }
    
    public async Task<List<Teacher>> GetListBySpecificationAsync(ISpecification<Teacher> specification)
    {
        var query = SpecificationEvaluator<Teacher>.GetQuery(_dbSet.AsQueryable(), specification);
        return await query.ToListAsync();
    }
}