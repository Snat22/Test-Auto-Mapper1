using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain.DTOs.GroupDtos;

public class GetGroupDto
{
    public int Id { get; set; }
    public required string GroupName { get; set; }
    public string? Description { get; set; }
    public Status Status { get; set; }
    [ForeignKey("CourseID")]
    public int CourseID { get; set; }
}
