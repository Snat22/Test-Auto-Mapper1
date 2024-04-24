using Domain.DTOs.AddStudentDtos;
using Domain.DTOs.StudentDtos;
using Domain.Responses;
using Infrastructure.Services.StudentServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[Route("/api/Student")]
[ApiController]
public class StudentController(IStudentService service):ControllerBase
{
    [HttpGet("Get-Students")]
    public async Task<Response<List<GetStudentDto>>> GetStudents()
    {
        return await service.GetStudents();
    }

     [HttpGet("studentId:int")]
    public async Task<Response<GetStudentDto>> GetStudentById(int studentId)
    {
        return await service.GetStudentById(studentId);
    }

    [HttpPost("Add-Student")]
    public async Task<Response<string>> AddStudent(AddStudentDto add)
    {
        return await service.AddStudent(add);
    }
    [HttpPut("Update-Student")]
    public async Task<Response<string>> UpdateStudent(UpdateStudentDto update)
    {
        return await service.UpdateStudent(update);
    }
    [HttpDelete("studnetId:int")]
    public async Task<Response<bool>> DeleteStudent(int studentId)
    {
        return await service.DeleteStudent(studentId);
    }
}
