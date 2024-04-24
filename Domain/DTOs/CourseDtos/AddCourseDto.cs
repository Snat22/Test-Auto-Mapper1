using Domain.Models;

namespace Domain.DTOs.CourseDtos;

public class AddCourseDto:BaseEntity
{
    public required string CourseName { get; set; }
    public string? Description { get; set; }
}
