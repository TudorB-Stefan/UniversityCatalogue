﻿namespace UniversityCatalog.Infrastructure.Repositories;

public interface IGenericManyToManyRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id1,int id2);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
}