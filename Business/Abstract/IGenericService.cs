using EntityLayer.Abstract;
using System.Linq.Expressions;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T> where T:class,IEntity,new()
    {
        Task<IList<T>> GetAll(Expression<Func<T, bool>>? filter = null);
        Task<T> GetById(int id);
        Task CreateAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
    }
}
