// using Domain.DTOs.MentorGroupDtos;
// using Domain.Responses;
// using Infrastructure.Services.MentorGroupService;
// using Microsoft.AspNetCore.Mvc;

// namespace WebApp.Controllers;
// [Route("/api/MentorGroup")]
// public class MentorGroupController(IMentorGroupService service):ControllerBase
// {    
//     [HttpGet("Get-MentorGroups")]
//     public async Task<Response<List<GetMentorGroupDto>>> GetMentorGroups()
//     {
//         return await service.GetMentorGroups();
//     }

//      [HttpGet("MentorGroupId:int")]
//     public async Task<Response<GetMentorGroupDto>> GetMentorGroupById(int MentorGroupId)
//     {
//         return await service.GetMentorGroupById(MentorGroupId);
//     }

//     [HttpPost("Add-MentorGroup")]
//     public async Task<Response<string>> AddMentorGroup(AddMentorGroupDto add)
//     {
//         return await service.AddMentorGroup(add);
//     }
//     [HttpPut("Update-MentorGroup")]
//     public async Task<Response<string>> UpdateMentorGroup(UpdateMentorGroupDto update)
//     {
//         return await service.UpdateMentorGroup(update);
//     }
//     [HttpDelete("studnetId:int")]
//     public async Task<Response<bool>> DeleteMentorGroup(int MentorGroupId)
//     {
//         return await service.DeleteMentorGroup(MentorGroupId);
//     }
// }
