using EntityLayer.Concrete;
using FluentValidation;

namespace ExamWeb.ValidationRules
{
    public class ExamValidation:AbstractValidator<Exam>     
    {
        public ExamValidation()
        {
            RuleFor(p => p.ExamDate).NotEmpty();
        }
    }
}
