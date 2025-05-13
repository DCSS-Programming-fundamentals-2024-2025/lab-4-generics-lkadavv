using generics.Interfaces;

namespace generics.Interfaces
{
    public interface IRepository<TEntity, TKey> 
        where TEntity : class, new()
        where TKey : struct
    {
        void Add(TKey id, TEntity entity);
        TEntity Get(TKey id);
        IEnumerable<TEntity> GetAll();
        void Remove(TKey id);
    }
}

public class InMemoryRepository<TEntity, TKey> : IRepository<TEntity, TKey>, IReadOnlyRepository<TEntity, TKey>, IWriteRepository<TEntity, TKey>
    where TEntity : class, new()
    where TKey : struct
{
    private Dictionary<TKey, TEntity> _storage = new Dictionary<TKey, TEntity>();

    public void Add(TKey id, TEntity entity)
    {
        _storage[id] = entity;
    }
    public TEntity Get(TKey id)
    {
        try
        {
            return _storage[id];
        }
        catch (KeyNotFoundException e)
        {
            Console.WriteLine(e.Message);
            return default;
        }
    }

    public IEnumerable<TEntity> GetAll()
    {
        return _storage.Values;
    }

    public void Remove(TKey id)
    {
        try
        {
            _storage.Remove(id);
        }
        catch (KeyNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
interface IWriteRepository<in TEntity, in TKey>
{
    void Add(TKey id, TEntity entity);
    void Remove(TKey id);
}
interface IReadOnlyRepository<out TEntity, in TKey>
{
    TEntity Get(TKey id);
    IEnumerable<TEntity> GetAll();

}
