using Domain.DTOs.AddStudentDtos;
using Domain.DTOs.StudentDtos;
using Domain.Responses;

namespace Infrastructure.Services.StudentServices;

public interface IStudentService
{
    public Task<Response<List<GetStudentDto>>> GetStudents();
    public Task<Response<GetStudentDto>> GetStudentById(int id);
    public Task<Response<string>> AddStudent(AddStudentDto add);
    public Task<Response<string>> UpdateStudent(UpdateStudentDto update);
    public Task<Response<bool>> DeleteStudent(int id);
}
