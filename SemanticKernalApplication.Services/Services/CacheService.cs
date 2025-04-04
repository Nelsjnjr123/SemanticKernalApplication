using SemanticKernalApplication.Core;
using SemanticKernalApplication.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections;
using System.Reflection;

namespace SemanticKernalApplication.Services.Services
{
    public class CacheService : ICacheService
    {
        #region variable
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<CacheService> _logger;
        private readonly IOptions<SemanticKernalApplicationSettings> _options;

        #endregion
        #region constructor
        public CacheService(IMemoryCache memoryCache, ILogger<CacheService> logger, IOptions<SemanticKernalApplicationSettings> options)
        {
            _memoryCache = memoryCache;
            _logger = logger;
            _options = options;
        }
        #endregion

        #region public methods
        public bool TryGetValue<TItem>(string key, out TItem value)
        {
            if (!_options.Value.APICacheSetting.EnableAPICache)
            {
                _logger.LogInformation($"===== CacheService: Caching is disabled============");
                value = default;
                return false;
            }
            if (!string.IsNullOrWhiteSpace(key))
            {
                if (_memoryCache.TryGetValue(key, out object result))
                {
                    _logger.LogInformation($"===== CacheService: Getting data from Cache for cacheKey:{key} ============");
                    if (result == null)
                    {
                        value = default;
                        return true;
                    }

                    if (result is TItem item)
                    {
                        value = item;
                        return true;
                    }
                }
            }
            value = default;
            return false;
        }

        public void RemoveAll(string exceptString = null)
        {
            if (!_options.Value.APICacheSetting.EnableAPICache)
            {
                _logger.LogInformation($"===== CacheService: Caching is disabled============");
            }
            else
            {
                #region As in .Net 7 there is no method to get All keys, So using reflection to get all the keys of cache.
                var coherentState = typeof(MemoryCache).GetField("_coherentState", BindingFlags.NonPublic | BindingFlags.Instance);
                var coherentStateValue = coherentState.GetValue(_memoryCache);
                var entriesCollection = coherentStateValue.GetType().GetProperty("EntriesCollection", BindingFlags.NonPublic | BindingFlags.Instance);
                var entriesCollectionValue = entriesCollection.GetValue(coherentStateValue) as ICollection;
                var keys = new List<string>();

                if (entriesCollectionValue != null)
                {
                    foreach (var item in entriesCollectionValue)
                    {
                        var methodInfo = item.GetType().GetProperty("Key");

                        var val = methodInfo.GetValue(item);

                        keys.Add(val.ToString());
                    }
                }

                if (keys.Any())
                {
                    if (!string.IsNullOrWhiteSpace(exceptString))
                    {
                        int removeCount = keys.RemoveAll(x => x == exceptString);
                        _logger.LogInformation($"===== CacheService: {exceptString} {removeCount} removed from Cache for all keys============");
                    }
                    foreach (var item in keys)
                    {
                        _memoryCache.Remove(item);
                        _logger.LogInformation($"=============Clearing cache of key {item}================");
                    }
                }
                _logger.LogInformation($"===== CacheService: Removing {keys?.Count} data from Cache for all keys ============");
                #endregion
            }
        }

        public bool Set<T>(string key, T value, MemoryCacheEntryOptions options = null)
        {
            if (!_options.Value.APICacheSetting.EnableAPICache)
            {
                _logger.LogInformation($"===== CacheService: Caching is disabled============");
                return false;
            }

            if (string.IsNullOrWhiteSpace(key))
                return false;

            if (options == null)
                options = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(_options.Value.APICacheSetting.SlidingExpirationCacheDurationInDays))
                    .SetAbsoluteExpiration(TimeSpan.FromDays(_options.Value.APICacheSetting.AbsoluteExpirationCacheDurationInDays));

            _memoryCache.Set(key, value, options);
            _logger.LogInformation($"=====CacheService: Setting data in Cache for cacheKey:{key} ============");
            return true;
        }

        public void Remove(string key)
        {
            _logger.LogInformation($"=====CacheService: Removing Cache for cacheKey:{key} ============");
            _memoryCache.Remove(key);
        }
        #endregion
    }
}
