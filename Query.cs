using HotChocolate.Data.Projections.Expressions;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Dtos;
using WebApplication2.Models;

namespace WebApplication2;

public class Query
{
    public async Task<List<ReportDto>> GetReportsNonProjected(
        SchoolContext schoolContext,
        CancellationToken cancellationToken)
    {
        return await schoolContext.Reports
            .Select(r => new ReportDto
            {
                Created = r.Created,
                Course = r.Course != null ? new CourseDto
                {
                    Id = r.Course.Id,
                    Title = r.Course.Name,
                    Attendees = r.Course.Attendees.Select(a => new AttendeeDto
                    {
                        PersonId = a.StudentId,
                        Name = a.Student.Name
                    }).ToList()
                } : null
            })
            .ToListAsync(cancellationToken);
    }
    
    [UseProjection]
    public async Task<List<ReportDto>> GetReportsProjected(
        SchoolContext schoolContext,
        IResolverContext resolverContext,
        CancellationToken cancellationToken)
    {
        return await schoolContext.Reports
            .Select(r => new ReportDto
            {
                Created = r.Created,
                Course = r.Course != null ? new CourseDto
                {
                    Id = r.Course.Id,
                    Title = r.Course.Name,
                    Attendees = r.Course.Attendees.Select(a => new AttendeeDto
                    {
                        PersonId = a.StudentId,
                        Name = a.Student.Name
                    }).ToList()
                } : null
            })
            .Project(resolverContext)
            .ToListAsync(cancellationToken);
    }
}