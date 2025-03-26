using System.Linq.Expressions;
using UniversityCatalog.Core.Interfaces;

namespace UniversityCatalog.Infrastructure.Specifications;

public class BaseSpecification<T> (Expression<Func<T,bool>> criteria) : ISpecification<T>
{
    public Expression<Func<T, bool>> Criteria { get; }=criteria;
    public List<Expression<Func<T, object>>> Includes { get; } = new();
    public Expression<Func<T,object>> OrderBy { get; private set; }
    public Expression<Func<T,object>> OrderByDescending { get; private set; }

    public void AddInclude(Expression<Func<T, object>> includeExpression)
    {
        Includes.Add(includeExpression);
    }
    public void ApplyOrderBy(Expression<Func<T,object>> orderBy)
    {
        OrderBy = orderBy;
    }
    public void ApplyOrderByDescending(Expression<Func<T,object>> orderByDescending)
    {
        OrderByDescending = orderByDescending;
    }
}