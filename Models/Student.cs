namespace WebApplication2.Models;

public class Student
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;

    // navigational properties
    public ICollection<CourseAttendee> Courses { get; set; } = new List<CourseAttendee>();
}