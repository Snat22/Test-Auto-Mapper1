using Domain.DTOs.MentorDtos;
using Domain.Responses;
using Infrastructure.Services.MentorServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[Route("/api/Mentor")]
[ApiController]
public class MentorController(IMentorService service):ControllerBase
{   
     [HttpGet("Get-Mentors")]
    public async Task<Response<List<GetMentorDto>>> GetMentors()
    {
        return await service.GetMentors();
    }

    [HttpGet("MentorId:int")]
    public async Task<Response<GetMentorDto>> GetMentorById(int MentorId)
    {
        return await service.GetMentorById(MentorId);
    }

    [HttpPost("Add-Mentor")]
    public async Task<Response<string>> AddMentor(AddMentorDto add)
    {
        return await service.AddMentor(add);
    }
    [HttpPut("Update-Mentor")]
    public async Task<Response<string>> UpdateMentor(UpdateMentorDto update)
    {
        return await service.UpdateMentor(update);
    }
    [HttpDelete("studnetId:int")]
    public async Task<Response<bool>> DeleteMentor(int MentorId)
    {
        return await service.DeleteMentor(MentorId);
    }
}
