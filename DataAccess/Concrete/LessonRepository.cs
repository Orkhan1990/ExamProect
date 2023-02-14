using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace DataAccessLayer.Concrete
{
    public class LessonRepository:GenericRepository<Lesson>,ILessonDal
    {
    }
}
