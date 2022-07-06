using Microsoft.EntityFrameworkCore;
using WebApplication2;
using WebApplication2.Models;
using WebApplication2.Utilities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SchoolContext>(o =>
{
    o.UseSqlite("Data Source=test.db");
    o.EnableSensitiveDataLogging();
});
builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddProjections()
    .RegisterDbContext<SchoolContext>();

var app = builder.Build();

app.MapGraphQL();

using (var scope = app.Services.CreateScope())
{
    var schoolContext = scope.ServiceProvider.GetRequiredService<SchoolContext>();
    await schoolContext.SeedDatabase();
}

app.Run();