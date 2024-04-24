using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain.Models;

public class Group:BaseEntity
{
    public required string GroupName { get; set; }
    public string? Description { get; set; }
    public Status Status { get; set; }
    [ForeignKey("CourseID")]
    public int CourseID { get; set; }
    public Course? Course { get; set; }
    public List<StudentGroup>? StudentGroups { get; set; }
    public List<MentorGroup>? MentorGroups { get; set; }
}
