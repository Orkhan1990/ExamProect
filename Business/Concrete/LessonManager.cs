using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Linq.Expressions;

namespace BusinessLayer.Concrete
{
    public class LessonManager :ILessonService
    {
        private readonly ILessonDal _lessonDal;
        public LessonManager(ILessonDal lessonDal)
        {
            _lessonDal = lessonDal;
        }
        public async Task CreateAsync(Lesson entity)
        {
            await _lessonDal.CreateAsync(entity);
        }

        public async Task DeleteAsync(Lesson entity)
        {
            await _lessonDal.DeleteAsync(entity);
        }

        public async Task<IList<Lesson>> GetAll(Expression<Func<Lesson, bool>>? filter = null)
        {
            return await _lessonDal.GetAll(filter);
        }

        public async Task<Lesson> GetById(int id)
        {
            return await _lessonDal.GetById(id);
        }

        public async Task UpdateAsync(Lesson entity)
        {
             await _lessonDal.UpdateAsync(entity);
        }
    }
}
