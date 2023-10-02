using System.Linq.Expressions;

namespace CarShop.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> filter);
        void add(T entity);
        void Remove(T entity);
    }
}
