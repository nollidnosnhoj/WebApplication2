namespace WebApplication2.Models;

public class CourseReport
{
    public Guid Id { get; set; }
    public DateTime Created { get; set; }
    public Guid? CourseId { get; set; }
    
    public virtual Course? Course { get; set; } = null!;
}