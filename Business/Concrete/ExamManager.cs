using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Linq.Expressions;

namespace BusinessLayer.Concrete
{
    public class ExamManager:IExamService
    {
        private readonly IExamDal _examDal;
        public ExamManager(IExamDal examDal)
        {
            _examDal = examDal;
        }
        public async Task CreateAsync(Exam entity)
        {
            await _examDal.CreateAsync(entity);
        }

        public async Task DeleteAsync(Exam entity)
        {
            await _examDal.DeleteAsync(entity);
        }

        public async Task<IList<Exam>> GetAll(Expression<Func<Exam, bool>>? filter = null)
        {
            return await _examDal.GetAll(filter);
        }

        public async Task<Exam> GetById(int id)
        {
            return await _examDal.GetById(id);
        }

        public async Task UpdateAsync(Exam entity)
        {
            await _examDal.UpdateAsync(entity);
        }
    }
}
