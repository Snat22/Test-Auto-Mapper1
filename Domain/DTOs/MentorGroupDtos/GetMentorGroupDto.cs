using Domain.Models;

namespace Domain.DTOs.MentorGroupDtos;

public class GetMentorGroupDto
{
    public int MentorId { get; set; }
    public Mentor? Mentor { get; set; }
    public int GroupId { get; set; }
    public Group? Group { get; set; }
}
