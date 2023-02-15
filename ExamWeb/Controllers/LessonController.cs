using AutoMapper;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTO_s.LessonDTO_s;
using ExamWeb.ValidationRules;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ExamWeb.Controllers
{
    public class LessonController : Controller
    {
        private readonly ILessonService _lessonService;
        private readonly IValidator<Lesson> _validator;
        private readonly IMapper _mapper;

        public LessonController(ILessonService lessonService, IValidator<Lesson> validator,IMapper mapper)
        {
            _lessonService =lessonService;
            _validator = validator;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var values = await _lessonService.GetAll();
            var objectValue=_mapper.Map<IList<LessonGetAllDTO>>(values);
            return View(objectValue);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(LessonCreateDTO lesson)
        {
            var entity = _mapper.Map<Lesson>(lesson);
            var validationResult = await _validator.ValidateAsync(entity);
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
            var lesson = _mapper.Map<LessonUpdateDTO>(entity);

            return View(lesson);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateLesson(LessonUpdateDTO lesson)
        {
            var entity = _mapper.Map<Lesson>(lesson);
            var validationResult = await _validator.ValidateAsync(entity);
            if (validationResult.IsValid)
            {
                await _lessonService.UpdateAsync(entity);
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
