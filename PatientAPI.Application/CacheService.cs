using Microsoft.Extensions.Caching.Memory;
using PatientAPI.Domain.Services;

namespace PatientAPI.Application
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _cache;

        public CacheService(IMemoryCache cache)
        {
            _cache = cache;
        }
        public async Task<T?> GetAsync<T>(string key) where T : class
        {
            _cache.TryGetValue(key, out T value);
            return await Task.FromResult(value);
        }

        public async Task RemoveAsync(string key)
        {
            _cache.Remove(key);
            await Task.CompletedTask;
        }

        public async Task SetAsync<T>(string key, T? value, TimeSpan? expiration = null) where T : class
        {
            var options = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expiration ?? TimeSpan.FromMinutes(5)
            };
            _cache.Set(key, value, options);
            await Task.CompletedTask;
        }
    }
}
