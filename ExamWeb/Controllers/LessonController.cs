using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ExamWeb.Controllers
{
    public class LessonController : Controller
    {
        private readonly ILessonService _lessonService;
        private readonly IValidator<Lesson> _validator;

        public LessonController(ILessonService lessonService, IValidator<Lesson> validator)
        {
            _lessonService =lessonService;
            _validator = validator;
        }
        public async Task<IActionResult> Index()
        {
            var values = await _lessonService.GetAll();
            return View(values);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Lesson lesson)
        {
            var validationResult = await _validator.ValidateAsync(lesson);
            if (validationResult.IsValid)
            {
                Lesson newLesson = new Lesson()
                {
                    NameOfLesson = lesson.NameOfLesson,
                    TeacherName = lesson.TeacherName,
                    TeacherSurname = lesson.TeacherSurname
                };
                await _lessonService.CreateAsync(newLesson);
                return RedirectToAction("Index", "Lesson");
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


        public async Task<IActionResult>DeleteLesson(int id)
        {
           
            var entity = await _lessonService.GetById(id);
            if (entity == null)
            {
                throw new ArgumentException("Belə dərs yoxdur!");
            }
            await _lessonService.DeleteAsync(entity);
            return RedirectToAction("Index","Lesson");

        }

        [HttpGet]
        public async Task<IActionResult>UpdateLesson(int id)
        {
            var entity = await _lessonService.GetById(id);
            if (entity == null)
            {
                throw new ArgumentException("Belə dərs yoxdur!");
            }

            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateLesson(Lesson lesson)
        {
            var validationResult = await _validator.ValidateAsync(lesson);
            if (validationResult.IsValid)
            {
                await _lessonService.UpdateAsync(lesson);
                return RedirectToAction("Index", "Lesson");
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
