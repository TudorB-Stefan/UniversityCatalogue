﻿using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using UniversityCatalog.Core.Entities;
using UniversityCatalog.Core.Interfaces;
using UniversityCatalog.Infrastructure.Data;
using UniversityCatalog.Infrastructure.Specifications;
using UniversityCatalog.Infrastructure.Specifications.CourseSpecifications;

namespace UniversityCatalog.Infrastructure.Repositories;

public class CourseRepository(ApplicationDbContext context) : IGenericRepository<Course>
{
    protected readonly DbContext _context = context;
    protected readonly DbSet<Course> _dbSet = context.Set<Course>();
    public async Task<List<Course>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }
    public async Task<Course> GetByIdAsync(int id)
    {
        var temp = await _dbSet.FindAsync(id);
        if (temp == null)
            throw new KeyNotFoundException("Course record not found");
        return temp;
    }
    public async Task AddAsync(Course course)
    {
        if (course == null)
            throw new KeyNotFoundException("Invalid Course");
        await _dbSet.AddAsync(course);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateAsync(Course course)
    {
        var temp = await _dbSet.FindAsync(course.Id);
        if (temp == null)
            throw new KeyNotFoundException("Course record not found");
        _dbSet.Entry(temp).CurrentValues.SetValues(course);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        var temp = await _dbSet.FindAsync(id);
        if (temp == null)
            throw new KeyNotFoundException("Course record not found");
        _dbSet.Remove(temp);
        await _context.SaveChangesAsync();
    }
    public async Task<List<Course>> GetListBySpecificationAsync(ISpecification<Course> specification)
    {
        var query = SpecificationEvaluator<Course>.GetQuery(_dbSet.AsQueryable(), specification);
        return await query.ToListAsync();
    }
}