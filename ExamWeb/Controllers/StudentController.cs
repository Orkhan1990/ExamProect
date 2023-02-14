using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ExamWeb.Controllers
{


    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IValidator<Student> _validator;
        public StudentController(IStudentService studentService,IValidator<Student> validator)
        {
                _studentService=studentService;
                _validator=validator;
        }
        public async Task<IActionResult> Index()
        {
            var values =await _studentService.GetAll();
            return View(values);
        }

        [HttpGet]

        public async Task<IActionResult> Create()
        {
            return View();  
        }
        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {

            return View();
        }
    }
}
