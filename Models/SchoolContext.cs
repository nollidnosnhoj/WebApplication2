using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;

public class SchoolContext : DbContext
{
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<CourseAttendee> Attendees => Set<CourseAttendee>();
    public DbSet<CourseReport> Reports => Set<CourseReport>();
    public DbSet<Student> Students => Set<Student>();

    public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CourseReport>()
            .HasOne(x => x.Course)
            .WithMany(x => x.Reports)
            .HasForeignKey(x => x.CourseId);
        
        modelBuilder.Entity<CourseAttendee>()
            .HasKey(x => new {x.CourseId, x.StudentId});
        modelBuilder.Entity<CourseAttendee>()
            .HasOne(x => x.Student)
            .WithMany(x => x.Courses)
            .HasForeignKey(x => x.StudentId);
        modelBuilder.Entity<CourseAttendee>()
            .HasOne(x => x.Course)
            .WithMany(x => x.Attendees)
            .HasForeignKey(x => x.CourseId);
    }
}