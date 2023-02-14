using EntityLayer.Abstract;

namespace EntityLayer.Concrete
{
    public class StudentLesson:IEntity
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public Student? Student { get; set; }

        public int LessonId { get; set; }
        public Lesson? Lesson { get; set; }

        public int Class { get; set; }


    }
}
