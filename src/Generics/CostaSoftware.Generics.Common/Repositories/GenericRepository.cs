using CostaSoftware.Generics.Common.Entities;

namespace CostaSoftware.Generics.Common;

// class allows reference types
public class GenericRepository<T> where T : class, IEntity, new()
{
    protected readonly List<T> _items = new();

    public T CreateItem()
    {
        return new();
    }

    public T GetById(Guid id) => _items.Single(item => item.Id == id);

    public void Add(T item)
    {
        if (item.Id == Guid.Empty)
        {
            item.Id = Guid.NewGuid();
        }


        _items.Add(item);
    }

    public void Save()
    {
        foreach (var item in _items)
        {
            Console.WriteLine(item);
        }
    }

    public bool Remove(T item)
    {
        return _items.Remove(item);
    }
}
