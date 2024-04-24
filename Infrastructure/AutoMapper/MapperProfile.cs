using AutoMapper;
using Domain.DTOs.AddStudentDtos;
using Domain.DTOs.CourseDtos;
using Domain.DTOs.GroupDtos;
using Domain.DTOs.MentorDtos;
using Domain.DTOs.StudentDtos;
using Domain.Models;

namespace Infrastructure.AutoMapper;

public class MapperProfile:Profile
{
    public MapperProfile()
    {
        //STUDENT
        CreateMap<Student,GetStudentDto>().ReverseMap();
        CreateMap<Student,AddStudentDto>().ReverseMap();
        CreateMap<Student,UpdateStudentDto>().ReverseMap();

        //COURSE
        CreateMap<Course,GetCourseDto>().ReverseMap();
        CreateMap<Course,AddCourseDto>().ReverseMap();
        CreateMap<Course,UpdateCourseDto>().ReverseMap();

        //MENTOR
        CreateMap<Mentor,AddMentorDto>().ReverseMap();
        CreateMap<Mentor,UpdateMentorDto>().ReverseMap();
        CreateMap<Mentor,GetMentorDto>().ReverseMap();

        //GROUP
        CreateMap<Group,AddGroupDto>().ReverseMap();
        CreateMap<Group,UpdateGroupDto>().ReverseMap();
        CreateMap<Group,GetGroupDto>().ReverseMap();

        //
    }
}
