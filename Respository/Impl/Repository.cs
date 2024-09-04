using Microsoft.EntityFrameworkCore;
using NetCrud2.DB;
using NetCrud2.Generics;
using System.Linq.Expressions;

namespace NetCrud2.Respository.Impl
{
    public abstract class Repository<T, ID> : IRepositoryGenerics<T, ID> where T : class
    {
        protected readonly ApplicationDbContext _db;
        protected  DbSet<T> _dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            _dbSet = db.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveChangesAsync();
            return entity;
        }

        public async Task Delete(T entity)
        {
             _dbSet.Remove(entity);
            await SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, bool tracked = true)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            else 
                query = query.AsNoTracking();
            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = _dbSet;
             query = query.Where(filter);
            return await query.FirstOrDefaultAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }

        public abstract Task<T> UpdateAsync(T entity);
    }
}
