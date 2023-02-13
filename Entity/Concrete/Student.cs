using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Student:IEntity
    {
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int Class { get; set; }
        public int StudentNumber { get; set; }

        public IList<StudentExam>? StudentExams { get; set; } = new List<StudentExam>();
        public IList<StudentLesson>? StudentLessons { get; set; } = new List<StudentLesson>();
    }
}
