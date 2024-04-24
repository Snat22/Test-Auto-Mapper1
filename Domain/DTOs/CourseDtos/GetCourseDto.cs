namespace Domain.DTOs.CourseDtos;

public class GetCourseDto
{
    public int Id { get; set; }
    public required string CourseName { get; set; }
    public string? Description { get; set; }
}
