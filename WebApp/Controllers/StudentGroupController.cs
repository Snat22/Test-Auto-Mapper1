// using Domain.Responses;
// using Microsoft.AspNetCore.Mvc;

// namespace WebApp.Controllers;

// public class StudentGroupController(IStuden)
// {
//         [HttpGet("Get-Students")]
//     public async Task<Response<List<GetStudentDto>>> GetStudents()
//     {
//         return await service.GetStudents();
//     }

//      [HttpGet("studentId:int")]
//     public async Task<Response<GetStudentDto>> GetStudentById(int studentId)
//     {
//         return await service.GetStudentById(studentId);
//     }

//     [HttpPost("Add-Student")]
//     public async Task<Response<string>> AddStudent(AddStudentDto add)
//     {
//         return await service.AddStudent(add);
//     }
//     [HttpPut("Update-Student")]
//     public async Task<Response<string>> UpdateStudent(UpdateStudentDto update)
//     {
//         return await service.UpdateStudent(update);
//     }
//     [HttpDelete("studnetId:int")]
//     public async Task<Response<bool>> DeleteStudent(int studentId)
//     {
//         return await service.DeleteStudent(studentId);
//     }
// }
