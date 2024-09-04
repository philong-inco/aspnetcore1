using System.Linq.Expressions;

namespace NetCrud2.Generics
{
    public interface IServiceGenerics<E, C, U, R>
    {
        Task<List<R>> GetAllList(Expression<Func<E, bool>> filter = null, bool tracked = true);
        Task<R> Get(Expression<Func<E, bool>> filter);
        Task<R> Add(C create);
        Task<R> Update(U update);
        Task Delete(string id);
    }
}
