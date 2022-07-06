namespace WebApplication2.Models;

public class Course
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Difficulty { get; set; } = null!;

    // navigational properties
    public ICollection<CourseReport> Reports { get; set; } = new List<CourseReport>();
    public ICollection<CourseAttendee> Attendees { get; set; } = new List<CourseAttendee>();
}