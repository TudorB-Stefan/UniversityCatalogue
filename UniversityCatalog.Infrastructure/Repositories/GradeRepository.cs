using API.Models;
using Microsoft.EntityFrameworkCore;

namespace UniversityCatalog.Infrastructure.Repositories;

public class GradeRepository(DbContext context) : IGenericManyToManyRepository<Grade>
{
    protected readonly DbContext _context = context;
    protected readonly DbSet<Grade> _dbSet=context.Set<Grade>();

    public async Task<IEnumerable<Grade>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<Grade> GetByIdAsync(int id1, int id2)
    {
        var temp = await _dbSet.FindAsync(id1, id2);
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
}