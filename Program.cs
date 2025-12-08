using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseUrls($"http://0.0.0.0:{port}");
        webBuilder.ConfigureServices(services =>
        {
            services.AddControllers();
        });
        webBuilder.Configure(app =>
        {
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
        });
    });

var app = builder.Build();
app.Run();

