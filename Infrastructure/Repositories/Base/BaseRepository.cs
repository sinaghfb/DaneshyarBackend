using Application.Dependencies.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories.Base
{
    public class BaseRepository<TKey, T> : IBaseRepository<TKey, T> where T : class
    {
        private readonly DbContext _context;
        public BaseRepository(DbContext context)
        {
            _context = context;

        }
        public  void Create(T entity)
        {
            _context.Entry(entity).State = EntityState.Unchanged;
            _context.Add(entity);
        }

        public async Task<bool> Exists(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().AnyAsync(expression);
        }

        public async Task<T> Get(TKey id)
        {
            return await _context.FindAsync<T>(id);
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(expression);
        }

        public async Task<List<T>> Get()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<bool> SaveChanges()
        {
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
