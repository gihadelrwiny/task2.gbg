using AutoMapper;
using task21.Helpers.DTO;
using task21.Models;

namespace task21.Helpers.Mapping
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Student, StudentDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.AgeGroup, opt => opt.MapFrom(src => src.Age < 18 ? "Minor" : "Adult"));
            CreateMap<CreateStudentDto, Student>();
            // because UpdateStudentDto has nullable properties, we need to ignore null values when mapping to Student
            CreateMap<UpdateStudentDto, Student>()
          .ForAllMembers(opt =>
              opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
