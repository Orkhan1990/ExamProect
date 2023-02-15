using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ExamWeb.Controllers
{
    public class ExamController : Controller
    {
        private readonly IExamService _examService;
        private readonly IValidator<Exam> _validator;
        public ExamController(IExamService examService, IValidator<Exam> validator)
        {
            _examService = examService;
            _validator = validator;
        }
        public async Task<IActionResult> Index()
        {
            var values = await _examService.GetAll();
            return View(values);
        }
    }
}
