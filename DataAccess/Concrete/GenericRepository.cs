using DataAccess.Context;
using DataAccessLayer.Abstract;
using EntityLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Concrete
{
    public class GenericRepository<T> : IGenericDal<T> where T : class, IEntity, new()
    {
       
        public async Task CreateAsync(T entity)
        {
            using var _dbContext = new ExamDb();
           await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            using var _dbContext = new ExamDb();
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IList<T>> GetAll(Expression<Func<T, bool>>? filter = null)
        {
            using var _dbContext = new ExamDb();
            if (filter == null)
            {
              return await _dbContext.Set<T>().ToListAsync();
            }
            else
            {
                return await _dbContext.Set<T>().Where(filter).ToListAsync();

            }

        }

        public async Task<T> GetById(int id)
        {
            using var _dbContext = new ExamDb();
            var entity =await _dbContext.Set<T>().FindAsync(id);
            if (entity == null)
            {
                throw new ArgumentException("The entity not found!");
            }

            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            using var _dbContext = new ExamDb();
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();

        }
    }
}
