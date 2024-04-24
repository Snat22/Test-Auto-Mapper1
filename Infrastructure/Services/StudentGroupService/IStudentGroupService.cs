using Domain.DTOs.StudentGroupDto;
using Domain.Responses;

namespace Infrastructure.Services.StudentGroupService;

public interface IStudentGroupService
{
    public Task<Response<List<GetStudentGroupDto>>> GetStudentGroups();
    public Task<Response<GetStudentGroupDto>> GetStudentGroupById(int id);
    public Task<Response<string>> AddStudentGroup(AddStudentGroupDtos add);
    public Task<Response<string>> UpdateStudentGroup(UpdateStudentGroupDto update);
    public Task<Response<bool>> DeleteStudentGroup(int id);
}
