using WebApplication2.Models;

namespace WebApplication2;

public class Mutation
{
    public async Task<bool> CreateReport(SchoolContext schoolContext, CancellationToken cancellationToken)
    {
        await schoolContext.Reports.AddAsync(new CourseReport {Created = DateTime.UtcNow}, cancellationToken);
        await schoolContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}