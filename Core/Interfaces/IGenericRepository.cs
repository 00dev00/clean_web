using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces;
public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T> Get(int id);
    IQueryable<T> GetAll();
    Task<T> GetEntityWithSpec(ISpecification<T> spec);
    Task<IReadOnlyList<T>> GetAllWithSpec(ISpecification<T> spec);
}