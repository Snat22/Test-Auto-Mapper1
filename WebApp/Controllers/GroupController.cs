using Domain.DTOs.GroupDtos;
using Domain.Responses;
using Infrastructure.Services.GroupServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[Route("/api/Group")]
public class GroupController(IGroupService service):ControllerBase
{
    [HttpGet("Get-Groups")]
    public async Task<Response<List<GetGroupDto>>> GetGroups()
    {
        return await service.GetGroups();
    }

    [HttpGet("GroupId:int")]
    public async Task<Response<GetGroupDto>> GetGroupById(int GroupId)
    {
        return await service.GetGroupById(GroupId);
    }

    [HttpPost("Add-Group")]
    public async Task<Response<string>> AddGroup(AddGroupDto add)
    {
        return await service.AddGroup(add);
    }
    [HttpPut("Update-Group")]
    public async Task<Response<string>> UpdateGroup(UpdateGroupDto update)
    {
        return await service.UpdateGroup(update);
    }
    [HttpDelete("studnetId:int")]
    public async Task<Response<bool>> DeleteGroup(int GroupId)
    {
        return await service.DeleteGroup(GroupId);
    }
}
