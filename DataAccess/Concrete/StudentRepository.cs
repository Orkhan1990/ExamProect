using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace DataAccessLayer.Concrete
{
    public class StudentRepository:GenericRepository<Student>,IStudentDal
    {
    }
}
