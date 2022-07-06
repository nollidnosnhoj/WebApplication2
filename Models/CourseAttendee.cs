namespace WebApplication2.Models;

public class CourseAttendee
{
    public Guid CourseId { get; set; }
    public Guid StudentId { get; set; }
    public DateTime AttendedDate { get; set; }

    // navigational properties
    public virtual Course Course { get; set; } = null!;
    public virtual Student Student { get; set; } = null!;
}