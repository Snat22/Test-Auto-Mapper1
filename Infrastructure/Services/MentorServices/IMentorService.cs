using Domain.DTOs.MentorDtos;
using Domain.Responses;

namespace Infrastructure.Services.MentorServices;

public interface IMentorService
{
    public Task<Response<List<GetMentorDto>>> GetMentors();
    public Task<Response<GetMentorDto>> GetMentorById(int id);
    public Task<Response<string>> AddMentor(AddMentorDto add);
    public Task<Response<string>> UpdateMentor(UpdateMentorDto update);
    public Task<Response<bool>> DeleteMentor(int id);
}

