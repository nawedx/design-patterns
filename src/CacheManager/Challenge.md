Great! Here's a Singleton challenge that will test your understanding and expose some tricky scenarios.

## Challenge: Application Cache Manager

**Scenario**: You're building a cache system for a web application. The cache needs to store frequently accessed data in memory, and you want to ensure there's only ONE cache instance across your entire application.

**Requirements**:

1. **Basic Singleton Pattern**:
    - Only one instance allowed
    - Thread-safe implementation
    - Lazy initialization (don't create until needed)

2. **Cache Functionality**:
    - `Put(string key, object value)` - Store data
    - `Get<T>(string key)` - Retrieve data with type safety
    - `Remove(string key)` - Remove specific item
    - `Clear()` - Clear all cached data
    - `GetStats()` - Return cache statistics (hit count, miss count, total items)

3. **Advanced Features** 🔥:
    - **Expiration**: Items should expire after a configurable time (default 5 minutes)
    - **Size Limit**: Cache should have a maximum size (default 100 items)
    - **LRU Eviction**: When cache is full, remove least recently used items
    - **Thread Safety**: Multiple threads should be able to use cache simultaneously

4. **Statistics Tracking**:
    - Track cache hits, misses, evictions
    - Track total items currently in cache
    - Track cache memory usage (bonus)

## The Tricky Parts 😈:

1. **Thread Safety Challenge**: Multiple threads trying to access cache simultaneously
2. **Expiration Logic**: How do you efficiently remove expired items?
3. **LRU Implementation**: How do you track "least recently used"?
4. **Memory Management**: What happens when cache grows too large?
5. **Singleton Testing**: How do you test a singleton without breaking the pattern?

## Expected Usage:

```csharp
// Should work like this:
var cache = CacheManager.Instance;

// Basic operations
cache.Put("user_123", new { Name = "John", Age = 30 });
var user = cache.Get<object>("user_123");

// Should handle different data types
cache.Put("settings", new List<string> { "theme=dark", "lang=en" });
cache.Put("counter", 42);

// Should handle expiration
Thread.Sleep(6000); // Wait 6 seconds (longer than 5-minute default)
var expiredUser = cache.Get<object>("user_123"); // Should return null

// Should provide statistics
var stats = cache.GetStats();
Console.WriteLine($"Hits: {stats.Hits}, Misses: {stats.Misses}");

// Thread safety test
var tasks = Enumerable.Range(0, 100)
    .Select(i => Task.Run(() => cache.Put($"key_{i}", $"value_{i}")))
    .ToArray();
Task.WaitAll(tasks);
```

## Bonus Challenges 🚀:

- **Configuration**: Allow cache size and expiration time to be configured
- **Persistence**: Save/load cache to disk on application shutdown/startup
- **Events**: Notify when items are added, removed, or expired
- **Memory Pressure**: Clear cache when system memory is low

## What I'm Testing:

1. **Correct Singleton Implementation** - Thread-safe, lazy, single instance
2. **Complex State Management** - Managing cache data, expiration, LRU
3. **Thread Safety** - Handling concurrent access correctly
4. **Algorithm Skills** - LRU implementation, efficient expiration
5. **Real-world Thinking** - Memory management, performance considerations

## Think About:

1. **What data structures will you use?** (Dictionary? LinkedList? Custom?)
2. **How will you handle expiration efficiently?** (Timer? Check on access?)
3. **How will you implement LRU?** (Track access time? Use LinkedList?)
4. **Where do you put the locks?** (Fine-grained? Coarse-grained?)
5. **How do you test this?** (How to reset singleton for tests?)

## Starter Template (If You Want):

```csharp
public class CacheManager
{
    // Your singleton implementation here
    
    public void Put(string key, object value) { }
    public T Get<T>(string key) { }
    public bool Remove(string key) { }
    public void Clear() { }
    public CacheStats GetStats() { }
}

public class CacheStats
{
    public int Hits { get; set; }
    public int Misses { get; set; }
    public int TotalItems { get; set; }
    public int Evictions { get; set; }
}
```

This challenge combines:
- **Singleton pattern** (what you're learning)
- **Thread safety** (locks, concurrent collections)
- **Data structures** (efficient cache implementation)
- **Algorithms** (LRU, expiration)
- **Real-world complexity** (memory management, performance)

Take your time to think through the design before coding. The key is getting the **Singleton part correct first**, then adding the cache functionality.

**Which part would you like to tackle first?** The basic singleton structure, or do you want to dive into the full challenge?

Remember: Start simple, then add complexity. Get the singleton working first! 🎯