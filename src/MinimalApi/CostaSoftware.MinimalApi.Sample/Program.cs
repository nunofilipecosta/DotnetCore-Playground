using AutoMapper;
using CostaSoftware.MinimalApi.Sample.Data;
using CostaSoftware.MinimalApi.Sample.Dtos;
using CostaSoftware.MinimalApi.Sample.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var sqlConBuilder = new SqlConnectionStringBuilder();
sqlConBuilder.ConnectionString = builder.Configuration.GetConnectionString("SqlDbConnection");
sqlConBuilder.UserID = builder.Configuration["UserId"];
sqlConBuilder.Password = builder.Configuration["Password"];

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(sqlConBuilder.ConnectionString));
builder.Services.AddScoped<ICommandRepository, CommandRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("api/v1/commands", async (ICommandRepository repo, IMapper mapper) =>
{
    var commands = await repo.GetAll();
    return Results.Ok(mapper.Map<IEnumerable<CommandReadDto>>(commands));
});

app.MapGet("api/v1/commands/{id}", async (ICommandRepository repo, IMapper mapper, int id) =>
{
    var command = await repo.GetById(id);
    if (command == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(mapper.Map<CommandReadDto>(command));
});


app.MapPost("api/v1/commands", async (ICommandRepository repo, IMapper mapper, CommandCreateDto dto) =>
{
    var command = mapper.Map<Command>(dto);
    await repo.Create(command);
    await repo.SaveChangesAsync();

    var cmdReadDto = mapper.Map<CommandReadDto>(command);
    return Results.Created($"api/v1/commands/{cmdReadDto.Id}", cmdReadDto);
});

app.MapPut("api/v1/commands/{id}", async (ICommandRepository repo, IMapper mapper, int id, CommandUpdateDto dto) =>
{

    var command = await repo.GetById(id);
    if (command == null)
    {
        return Results.NotFound();
    }

    mapper.Map(dto, command);

    await repo.SaveChangesAsync();

    return Results.NoContent();

});

app.MapDelete("api/v1/commands/{id}", async (ICommandRepository repo, IMapper mapper, int id) =>
{
    var command = await repo.GetById(id);
    if (command == null)
    {
        return Results.NotFound();
    }

    repo.Delete(command);

    await repo.SaveChangesAsync();

    return Results.NoContent();
});

app.Run();
