using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace DataAccessLayer.Concrete
{
    public class ExamRepository:GenericRepository<Exam>,IExamDal
    {
    }
}
