using CostaSoftware.MinimalApi.Sample.Models;

namespace CostaSoftware.MinimalApi.Sample.Data;

public interface ICommandRepository
{
    Task SaveChangesAsync();

    Task DeleteChanges();

    Task<Command?> GetById(int id);

    Task<IEnumerable<Command>> GetAll();

    Task Create(Command command);

    void Delete(Command command);
}
