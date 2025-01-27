
using System.Linq.Expressions;

namespace decaf.Application.IRepositories;

public interface IRepository<T> where T : class
{
    Task<T> Create(T entity);
    Task<List<T>> GetAll();
    Task<List<T>> GetAll(params Expression<Func<T, object>>[] includeProperties);
    Task<T> Get(int id);
    Task<T> Get(int id, params Expression<Func<T, object>>[] includeProperties);
    Task<T> Update(T entity);
    Task<bool> Delete(int id);
}
