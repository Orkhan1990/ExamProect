using EntityLayer.Abstract;

namespace EntityLayer.Concrete
{
    public class StudentExam:IEntity
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public Student? Student { get; set; }

        public int ExamId { get; set; }
        public Exam? Exam { get; set; }

        public int StudentNumber { get; set; }
        public int ExamScore { get; set; }


    }
}
