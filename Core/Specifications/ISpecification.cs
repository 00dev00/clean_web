using System.Linq.Expressions;

namespace Core.Specifications;

public interface ISpecification<T>
{
    Expression<Func<T, bool>> Criteria  { get; }
    public List<Expression<Func<T, object>>> Includes { get; }   
}
