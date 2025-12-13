var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks();

var app = builder.Build();

app.MapHealthChecks("/health");

app.UseHttpsRedirection();

app.MapGet("/", () => 
@"Hello Kubernetes
This is a sample ASP.NET Core API running inside a Kubernetes cluster");

app.Run();