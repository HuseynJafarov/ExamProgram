using Application.DTOs.Exam;
using Application.DTOs.Lesson;
using Application.DTOs.Student;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Exam, ExamListDTO>();

            CreateMap<StudentCreateAndUpdateDto, Student >();
            CreateMap<Student, StudentListDto>();
            CreateMap<StudentCreateAndUpdateDto, Student>().ReverseMap();


            CreateMap<LessonCreateAndUpdateDto, Lesson>();
            CreateMap<Lesson, LessonListDto>();
            CreateMap<LessonCreateAndUpdateDto, Lesson>().ReverseMap();


        }
    }
}
