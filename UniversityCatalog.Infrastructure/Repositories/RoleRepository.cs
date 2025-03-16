using API.Models;
using Microsoft.EntityFrameworkCore;
using UniversityCatalog.Infrastructure.Specifications;

namespace UniversityCatalog.Infrastructure.Repositories;

public class RoleRepository(DbContext context) : IGenericRepository<Role>
{
    protected readonly DbContext _context = context;
    protected readonly DbSet<Role> _dbSet=context.Set<Role>();
    public async Task<IEnumerable<Role>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<Role> GetByIdAsync(int id)
    {
        var temp = await _dbSet.FindAsync(id);
        if (temp == null)
            throw new KeyNotFoundException("Role record not found");
        return temp;
    }

    public async Task AddAsync(Role role)
    {
        if (role == null)
            throw new KeyNotFoundException("Invalid Role");
        await _dbSet.AddAsync(role);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Role role)
    {
        var temp = await _dbSet.FindAsync(role.Id);
        if(temp==null)
            throw new KeyNotFoundException("Role record not found");
        _dbSet.Entry(temp).CurrentValues.SetValues(role);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var temp = await _dbSet.FindAsync(id);
        if (temp == null)
            throw new KeyNotFoundException("Role record not found");
        _dbSet.Remove(temp);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Role>> GetListBySpecificationAsync(ISpecification<Role> specification)
    {
        var query = SpecificationEvaluator<Role>.GetQuery(_dbSet.AsQueryable(), specification);
        return await query.ToListAsync();
    }
}