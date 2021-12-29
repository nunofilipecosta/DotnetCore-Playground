using CostaSoftware.HealthCheck.Controllers;
using CostaSoftware.HealthCheck.Models;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Net.Mime;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks()
    .AddCheck<SampleHealthCheck>("Sample", null, new List<string> { "READY", "LIVE" })
    .AddTypeActivatedCheck<SampleTypedHealthCheck>("SampleTyped", HealthStatus.Unhealthy, new List<string> { "READY" }, "param1", "param2");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapHealthChecks("/ready", new ReadyHealthCheckOptions("CostaSoftwareApplication"));

app.MapHealthChecks("/live", new LiveHealthCheckOptions("CostaSoftwareApplication"));

app.MapControllers();

app.Run();
