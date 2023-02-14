using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Linq.Expressions;

namespace BusinessLayer.Concrete
{
    public class StudentManger : IStudentService
    {
        private readonly IStudentDal _studentDal;
        public StudentManger(IStudentDal studentDal)
        {
            _studentDal = studentDal;
        }
        public async Task CreateAsync(Student entity)
        {
            await _studentDal.CreateAsync(entity);
        }

        public async Task DeleteAsync(Student entity)
        {
            await _studentDal.DeleteAsync(entity);
        }

        public async Task<IList<Student>> GetAll(Expression<Func<Student, bool>>? filter = null)
        {
           return await _studentDal.GetAll(filter);
        }

        public async Task<Student> GetById(int id)
        {
            return await _studentDal.GetById(id);
        }

        public async Task UpdateAsync(Student entity)
        {
            await _studentDal.UpdateAsync(entity);
        }
    }
}
