using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    internal interface IGenericService<T> where T:class,IEntity
    {
        Task<IList<T>> GetAll(Expression<Func<T, bool>>? filter = null);
        Task<T> GetById(int id);
        void CreateAsync(T entity);
        void DeleteAsync(T entity);
        void UpdateAsync(T entity);
    }
}
