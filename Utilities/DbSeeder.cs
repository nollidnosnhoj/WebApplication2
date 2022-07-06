using Bogus;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Utilities;

public static class DbSeeder
{
    public static async Task SeedDatabase(this SchoolContext dbContext)
    {
        if (await dbContext.Reports.AnyAsync())
        {
            return;
        }

        var course1 = new Course {Name = "Computer Science", Difficulty = "Hard"};
        var course2 = new Course {Name = "Physics", Difficulty = "Hard"};

        var studentFactory = new Faker<Student>()
            .RuleFor(x => x.Name, f => f.Name.FullName())
            .RuleFor(x => x.Email, f => f.Internet.ExampleEmail());

        var students1 = studentFactory.Generate(5);
        var students2 = studentFactory.Generate(5);

        await dbContext.Courses.AddRangeAsync(course1, course2);
        await dbContext.Students.AddRangeAsync(students1.Concat(students2));
        await dbContext.SaveChangesAsync();

        var report1 = new CourseReport {Created = DateTime.UtcNow, CourseId = course1.Id};
        var report2 = new CourseReport {Created = DateTime.UtcNow, CourseId = course2.Id};
        await dbContext.Reports.AddRangeAsync(report1, report2);
        await dbContext.SaveChangesAsync();

        var attendees1 = students1.Select(x => new CourseAttendee
        {
            CourseId = course1.Id,
            StudentId = x.Id,
            AttendedDate = DateTime.UtcNow
        });
        
        var attendees2 = students2.Select(x => new CourseAttendee
        {
            CourseId = course2.Id,
            StudentId = x.Id,
            AttendedDate = DateTime.UtcNow
        });

        await dbContext.Attendees.AddRangeAsync(attendees1.Concat(attendees2));
        await dbContext.SaveChangesAsync();
    }
}