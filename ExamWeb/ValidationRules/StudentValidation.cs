using EntityLayer.Concrete;
using FluentValidation;

namespace ExamWeb.ValidationRules
{
    public class StudentValidation:AbstractValidator<Student>
    {
        public StudentValidation()
        {
            RuleFor(p => p.Name).MaximumLength(30).NotEmpty();
            RuleFor(p=>p.Surname).MaximumLength(30).NotEmpty();
      
        }
    }
}
