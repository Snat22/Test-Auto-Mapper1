using Domain.Enums;

namespace Domain.Models;

public class Course:BaseEntity
{
    public required string CourseName { get; set; }
    public string? Description { get; set; }
    public Status Status { get; set; }
    public List<Group>? Groups { get; set; }

}
