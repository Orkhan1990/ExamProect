using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Exam:IEntity
    {
        public int Id { get; set; }
        public DateTime ExamDate { get; set; }
        public int ExamScore { get; set; }

        public IList<Lesson> Lessons { get; set; } = new List<Lesson>();
        public IList<StudentExam> StudentExams { get; set; }=new List<StudentExam>();

    }
}
