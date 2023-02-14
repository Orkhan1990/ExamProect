using EntityLayer.Abstract;

namespace EntityLayer.Concrete
{
    public class ExamLesson:IEntity
    {
        public int Id { get; set; }

        public int ExamId { get; set; }
        public Exam?  Exam { get; set; }

        public int LessonId { get; set; }
        public Lesson? Lesson { get; set; }
        public char LessonCode { get; set; }

    }
}
