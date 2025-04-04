using Microsoft.Extensions.Caching.Memory;

namespace SemanticKernalApplication.Services.Interfaces
{
    public interface ICacheService
    {
        /// <summary>
        /// Get Data using key
        /// </summary>
        /// <typeparam name="TItem"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool TryGetValue<TItem>(string key, out TItem value);

        /// <summary>
        /// Set Data with Value and Expiration Time of Key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expirationTime"></param>
        /// <returns></returns>
        bool Set<T>(string key, T value, MemoryCacheEntryOptions options = null);

        /// <summary>
        /// Remove All cache data
        /// </summary>
        void RemoveAll(string exceptString = null);

        /// <summary>
        /// Remove cache data
        /// </summary>
        /// <param name="key"></param>
        void Remove(string key);
    }
}
