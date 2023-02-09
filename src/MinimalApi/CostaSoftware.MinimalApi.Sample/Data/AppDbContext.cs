using CostaSoftware.MinimalApi.Sample.Models;
using Microsoft.EntityFrameworkCore;

namespace CostaSoftware.MinimalApi.Sample.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Command> Commands => Set<Command>();
}
