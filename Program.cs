var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline
app.UseRouting();

app.MapGet("/", () => 
{
    return Results.Ok(new 
    { 
        message = "Hello World from .NET on Windows Cloud Foundry!",
        timestamp = DateTime.UtcNow,
        platform = Environment.OSVersion.ToString()
    });
});

app.MapGet("/health", () => Results.Ok(new { status = "healthy" }));

app.Run();

