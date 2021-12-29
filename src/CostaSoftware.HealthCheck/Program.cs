using CostaSoftware.HealthCheck.Controllers;
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
    .AddCheck<SampleHealthCheck>("Sample")
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

var options = new HealthCheckOptions();

options.ResponseWriter = async (c, r) =>
{
    c.Response.ContentType = MediaTypeNames.Application.Json;

    var result = System.Text.Json.JsonSerializer.Serialize(new
    {
        Description = "",
        Status = r.Status.ToString(),
        Errors = r.Entries.Select(e => new { key = e.Key, value = Enum.GetName(typeof(HealthStatus), e.Value.Status) })
    });
    await c.Response.WriteAsync(result);
};



app.MapHealthChecks("/status", options);

app.MapHealthChecks("/ready", new HealthCheckOptions() { });

app.MapControllers();

app.Run();
