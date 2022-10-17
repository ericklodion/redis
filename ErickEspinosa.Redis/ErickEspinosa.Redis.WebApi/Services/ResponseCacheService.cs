using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace ErickEspinosa.Redis.WebApi.Services
{
    public interface IResponseCacheService
    {
        Task SetCacheResponseAsync(string cacheKey, object response, TimeSpan timeLive);
        Task<string> GetCachedResponseAsync(string cacheKey);
    }
    public class ResponseCacheService : IResponseCacheService
    {
        private readonly IDistributedCache _distributedCache;

        public ResponseCacheService(IDistributedCache distributedCache)
        => _distributedCache = distributedCache;

        public async Task<string> GetCachedResponseAsync(string cacheKey)
        {
            return await _distributedCache.GetStringAsync(cacheKey);
        }

        public async Task SetCacheResponseAsync(string cacheKey, object response, TimeSpan timeLive)
        {
            if (response is null) return;

            var serializedResponse = JsonConvert.SerializeObject(response);

            await _distributedCache.SetStringAsync(cacheKey, serializedResponse, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = timeLive
            });
        }
    }
}
