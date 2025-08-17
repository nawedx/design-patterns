Console.WriteLine("Building Application Cache Manager!");

public class CacheManager
{
    private static readonly Lazy<CacheManager> _instance = new Lazy<CacheManager>(() => new CacheManager());

    private IDictionary<string, object> _cache = new Dictionary<string, object>();

    private long _hitCount = 0;
    
    private long _missCount = 0;
    
    private CacheManager()
    {
        Console.WriteLine("Cache Manager Created!");
    }

    public static CacheManager Instance = _instance.Value;

    public void Put(string key, object value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(key);
        
        _cache[key] = value;
    }

    public T? Get<T>(string key)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(key);

        if (_cache.TryGetValue(key, out var value))
        {
            _hitCount++;

            if (value is T typedValue)
            {
                return typedValue;
            }

            return default;
        }

        _missCount++;

        return default;
    }

    public bool Remove(string key)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(key);

        return _cache.Remove(key);
    }

    public void Clear()
    {
        _cache.Clear();
    }

    public CacheStats GetStats()
    {
        return new CacheStats(_hitCount, _missCount, _cache.LongCount());
    }

    public record CacheStats(long HitCount, long MissCount, long TotalItems);
}