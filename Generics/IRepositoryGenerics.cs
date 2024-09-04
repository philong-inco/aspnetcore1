using NetCrud2.Models;
using System.Linq.Expressions;

namespace NetCrud2.Generics
{
    public interface IRepositoryGenerics<T, ID> where T : class
    {
        Task<T> CreateAsync(T entity);
        Task Delete(T entity);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, bool tracked = true);
        Task<T> GetAsync(Expression<Func<T, bool>> filter = null);
        Task SaveChangesAsync();
        Task<T> UpdateAsync(T entity);
    }
}
