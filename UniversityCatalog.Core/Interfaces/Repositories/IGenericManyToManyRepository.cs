namespace UniversityCatalog.Core.Interfaces;

public interface IGenericM2MRepository<T> where T : class
{
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id1,int id2);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
    Task<List<T>> GetListBySpecificationAsync(ISpecification<T> specification);
}