using ErickEspinosa.Redis.WebApi.Cache;
using ErickEspinosa.Redis.WebApi.Services;

namespace ErickEspinosa.Redis.WebApi.Installer
{
    public static class CacheInstaller
    {
        public static void InstallCacheServices(this IServiceCollection services, IConfiguration configuration)
        {
            var redisCacheSettings = new RedisCacheSettings();
            configuration.GetSection(nameof(redisCacheSettings)).Bind(redisCacheSettings);

            services.AddSingleton(redisCacheSettings);

            if (!redisCacheSettings.Enabled) return;

            services.AddStackExchangeRedisCache(options => options.Configuration = redisCacheSettings.ConnectionString);
            services.AddSingleton<IResponseCacheService, ResponseCacheService>();
        }
    }
}
