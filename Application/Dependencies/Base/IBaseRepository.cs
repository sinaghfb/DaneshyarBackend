using System.Linq.Expressions;

namespace Application.Dependencies.Base
{
    public interface IBaseRepository<Tkey, T> where T : class
    {
        Task<T> Get(Tkey id);
        Task<T> Get(Expression<Func<T, bool>> expression);
        Task<List<T>> Get();
        void Create(T entity);
        Task<bool> Exists(Expression<Func<T, bool>> expression);
        Task<bool> SaveChanges();
    }
}
