using Microsoft.AspNetCore.Mvc;
using UniversityCatalog.Infrastructure.Specifications;

namespace UniversityCatalog.Infrastructure.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
    Task<List<T>> GetListBySpecificationAsync(ISpecification<T> specification);
}
