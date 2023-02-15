using EntityLayer.Concrete;
using FluentValidation;

namespace ExamWeb.ValidationRules
{
    public class LessonValidation:AbstractValidator<Lesson>
    {
        public LessonValidation()
        {
            RuleFor(p => p.NameOfLesson).NotEmpty().MaximumLength(30);
            RuleFor(p=>p.TeacherName).NotEmpty().MaximumLength(30);
            RuleFor(p=>p.TeacherSurname).NotEmpty().MaximumLength(30);
           
        }
    }
}
