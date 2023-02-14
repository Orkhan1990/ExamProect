using EntityLayer.Abstract;

namespace EntityLayer.Concrete
{
    public class Exam:IEntity
    {
        public int Id { get; set; }
        public DateTime ExamDate { get; set; }

        public IList<StudentExam> StudentExams { get; set; }=new List<StudentExam>();
        public IList<ExamLesson> ExamLessons { get; set; } = new List<ExamLesson>();


    }
}
