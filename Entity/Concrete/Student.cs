using EntityLayer.Abstract;

namespace EntityLayer.Concrete
{
    public class Student:IEntity
    {
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Surname { get; set; }

        public IList<StudentExam>? StudentExams { get; set; } = new List<StudentExam>();
        public IList<StudentLesson>? StudentLessons { get; set; } = new List<StudentLesson>();

        public Student()
        {

        }
        public Student(string name,string surname)
        {
            this.Surname = surname;
            this.Name = name;
        }
               
    }
}
