namespace WebApplication2.Dtos;

public class ReportDto
{
    public DateTime Created { get; set; }
    public CourseDto? Course { get; set; } = null!;
}