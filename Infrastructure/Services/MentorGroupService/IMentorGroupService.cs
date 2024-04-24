using Domain.DTOs.MentorGroupDtos;
using Domain.Responses;

namespace Infrastructure.Services.MentorGroupService;

public interface IMentorGroupService
{
    public Task<Response<List<GetMentorGroupDto>>> GetMentorGroups();
    public Task<Response<GetMentorGroupDto>> GetMentorGroupById(int Id);
    public Task<Response<string>> AddMentorGroup(AddMentorGroupsDto add);
    public Task<Response<string>> UpdateMentroGroup(UpdateMentorGroupDto update);
    public Task<Response<bool>> DeleteMentorGroup(int Id);
}
