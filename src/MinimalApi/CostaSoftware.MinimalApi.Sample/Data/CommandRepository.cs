using CostaSoftware.MinimalApi.Sample.Models;
using Microsoft.EntityFrameworkCore;

namespace CostaSoftware.MinimalApi.Sample.Data;

public class CommandRepository : ICommandRepository
{
    private readonly AppDbContext _context;

    public CommandRepository(AppDbContext appDbContext)
    {
        this._context = appDbContext;
    }

    public async Task Create(Command command)
    {
        if(command == null)
        {
            throw new ArgumentNullException(nameof(command));
        }

        await _context.AddAsync(command);
    }

    public async void Delete(Command command)
    {
        if(command == null)
        {
            throw new ArgumentNullException(nameof(command));
        }

        _context.Commands.Remove(command);
    }

    public async Task DeleteChanges()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Command>> GetAll()
    {
        return await _context.Commands.ToListAsync();
    }

    public async Task<Command?> GetById(int id)
    {
        return await _context.Commands.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
