using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.IServicies
{
    public interface IResponseCacheService
    {
        Task CacheResponseAsync(string catchKey, object response, TimeSpan timeToLive);
        Task<string> GetCachedResponseAsync(string cacheKey);

    }
}
