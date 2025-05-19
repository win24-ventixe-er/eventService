using Microsoft.EntityFrameworkCore;
using Presentation.Data;
using Presentation.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EventsDatabaseConnection")));

var app = builder.Build();
app.MapOpenApi();
app.UseHttpsRedirection();

app.UseCors(options =>
{
    options.AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod();
});

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
