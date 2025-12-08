using System;

var builder = WebApplication.CreateBuilder(args);

// Get port from Cloud Foundry PORT environment variable, default to 8080
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

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

