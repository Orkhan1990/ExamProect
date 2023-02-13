using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Lesson:IEntity
    {
        public int Id { get; set; }
        public char CodeOfLesson { get; set; }
        public string? NameOfLesson { get; set; }
        public int Class { get; set; }
        public string? TeacherName { get; set; }
        public string? TecaherSurname { get; set; }

        public int ExamId { get; set; }
        public Exam? Exam { get; set; }

        public IList<StudentLesson> StudentLessons { get; set; } =new List<StudentLesson>();
    }
}
