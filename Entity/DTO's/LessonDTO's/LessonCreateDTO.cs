using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTO_s.LessonDTO_s
{
    public class LessonCreateDTO
    {
        public string? NameOfLesson { get; set; }
        public string? TeacherName { get; set; }
        public string? TeacherSurname { get; set; }
    }
}
