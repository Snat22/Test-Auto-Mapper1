using Domain.DTOs.CourseDtos;
using Domain.Responses;

namespace Infrastructure.Services.CourseServices;

public interface ICourseService
{
    public Task<Response<List<GetCourseDto>>> GetCourses();
    public Task<Response<GetCourseDto>> GetCourseById(int id);
    public Task<Response<string>> AddCourse(AddCourseDto add);
    public Task<Response<string>> UpdateCourse(UpdateCourseDto update);
    public Task<Response<bool>> DeleteCourse(int id);
}
