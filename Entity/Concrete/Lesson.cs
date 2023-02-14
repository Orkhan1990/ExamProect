using EntityLayer.Abstract;

namespace EntityLayer.Concrete
{
    public class Lesson:IEntity
    {
        public int Id { get; set; }
        public string? NameOfLesson { get; set; }
        public string? TeacherName { get; set; }
        public string? TecaherSurname { get; set; }


        public IList<ExamLesson> ExamLessons { get; set; } = new List<ExamLesson>();

        public IList<StudentLesson> StudentLessons { get; set; } =new List<StudentLesson>();
    }
}
