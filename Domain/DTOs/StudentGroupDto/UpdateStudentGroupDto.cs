using Domain.Models;

namespace Domain.DTOs.StudentGroupDto;

public class UpdateStudentGroupDto
{
    public int Id { get; set; }
    public int StudentId { get; set; }  
    public Student? Student { get; set; }
    public int GroupId { get; set; }
    public Group? Group { get; set; }
}
