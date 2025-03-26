using Microsoft.AspNetCore.Mvc;
using UniversityCatalog.Core.Interfaces;
using UniversityCatalog.Infrastructure.Specifications;

namespace UniversityCatalog.Core.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
    Task<List<T>> GetListBySpecificationAsync(ISpecification<T> specification);
}
