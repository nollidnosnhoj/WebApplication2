namespace WebApplication2.Dtos;

public class CourseDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public List<AttendeeDto> Attendees { get; set; } = new();
}