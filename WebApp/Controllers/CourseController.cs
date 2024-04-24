using Domain.DTOs.CourseDtos;
using Domain.Responses;
using Infrastructure.Services.CourseServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[Route("/api/Course")]
[ApiController]
public class CourseController(ICourseService service):ControllerBase
{   
    [HttpGet("Get-Course")]
    public async Task<Response<List<GetCourseDto>>> GetCourse()
    {
        return await service.GetCourses();
    }

     [HttpGet("CourseId:int")]
    public async Task<Response<GetCourseDto>> GetCourseById(int CourseId)
    {
        return await service.GetCourseById(CourseId);
    }

    [HttpPost("Add-Course")]
    public async Task<Response<string>> AddCourse(AddCourseDto add)
    {
        return await service.AddCourse(add);
    }
    [HttpPut("Update-Course")]
    public async Task<Response<string>> UpdateCourse(UpdateCourseDto update)
    {
        return await service.UpdateCourse(update);
    }
    [HttpDelete("studnetId:int")]
    public async Task<Response<bool>> DeleteCourse(int CourseId)
    {
        return await service.DeleteCourse(CourseId);
    }
}
