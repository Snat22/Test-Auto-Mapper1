using Domain.DTOs.GroupDtos;
using Domain.Responses;

namespace Infrastructure.Services.GroupServices;

public interface IGroupService
{
    public Task<Response<List<GetGroupDto>>> GetGroups();
    public Task<Response<GetGroupDto>> GetGroupById(int id);
    public Task<Response<string>> AddGroup(AddGroupDto add);
    public Task<Response<string>> UpdateGroup(UpdateGroupDto update);
    public Task<Response<bool>> DeleteGroup(int id);
}
