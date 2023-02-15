using AutoMapper;
using EntityLayer.Concrete;
using EntityLayer.DTO_s.LessonDTO_s;

namespace ExamWeb.Profiles
{
    public class LessonProfile:Profile
    {
        public LessonProfile()
        {
            CreateMap<Lesson,LessonGetAllDTO>();
            CreateMap<Lesson, LessonCreateDTO>().ReverseMap();
            CreateMap<Lesson, LessonUpdateDTO>().ReverseMap();
        }
    }
}
