namespace Domain.DTOs.CourseDtos;

public class UpdateCourseDto
{
    public int Id { get; set; }
    public required string CourseName { get; set; }
    public string? Description { get; set; }
}
