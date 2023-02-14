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

            var validationResult = await _validator.ValidateAsync(student);
            if (validationResult.IsValid)
            {
                Student newStudent = new Student();
                newStudent.Name = student.Name;
                newStudent.Surname = student.Surname;
                await _studentService.CreateAsync(newStudent);
                return RedirectToAction("Index", "Student");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                            
            }

            return View();
        }

       

        public async Task<IActionResult>DeleteStudent(int id)
        {
            var entity =await _studentService.GetById(id);
            if (entity == null)
            {
                throw new ArgumentException("Belə bir şagird sistemdə yoxdur!");
            }

            await _studentService.DeleteAsync(entity);
            return RedirectToAction("Index", "Student");
        }

        [HttpGet]
        public async Task<IActionResult>UpdateStudent(int id)
        {
            var entity=await _studentService.GetById(id);
            if (entity == null)
            {
                throw new ArgumentException("Belə bir şagird sistemdə yoxdur!");
            }


            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStudent(Student student)
        {
            var validationResult = await _validator.ValidateAsync(student);
            if (validationResult.IsValid)
            {
                //Student newStudent = new Student();
                //newStudent.Name = student.Name;
                //newStudent.Surname = student.Surname;
                await _studentService.UpdateAsync(student);
                return RedirectToAction("Index", "Student");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

            }

            return View();
        }
    }
}
