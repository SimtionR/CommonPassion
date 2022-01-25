using CommonPassion_Backend.Data.IServicies;
using CommonPassion_Backend.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CacheAttribute : Attribute, IAsyncActionFilter
    {
        private readonly int timeToLiveSeconds;

        public CacheAttribute(int timeToLiveSeconds)
        {
            this.timeToLiveSeconds = timeToLiveSeconds;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // we dont use dependey injection here bc we would need to inject it whereeve we use it 
            var cacheSettings = context.HttpContext.RequestServices.GetRequiredService<RedisCacheSettings>();
            if(!cacheSettings.Enabled)
            {
                await next();
                return;

            }


            var cacheService = context.HttpContext.RequestServices.GetRequiredService<IResponseCacheService>();

            // we create the cacheKey by getting the actual url, query string params and order them by name
            var cacheKey = GenerateCacheKeyFromRequest(context.HttpContext.Request);


            //check if request is cached
            var cachedResponse = await cacheService.GetCachedResponseAsync(cacheKey);

            // if true return

            if(!string.IsNullOrEmpty(cachedResponse))
            {
                var contentResult = new ContentResult
                {
                    Content =cachedResponse,
                    ContentType = "application/json",
                    StatusCode = 200
                };

                context.Result = contentResult;
                return ;
            }

            // we go and take the response from the actual request bc it is not cached
            var executedContext =await next();

            //cache the response   (executedContext.Result is OkObjectResult okObjectResult ) initial if
            if (executedContext != null)
            {
                // await cacheService.CacheResponseAsync(cacheKey, okObjectResult.Value, TimeSpan.FromSeconds(timeToLiveSeconds));
                await cacheService.CacheResponseAsync(cacheKey, executedContext.Result, TimeSpan.FromSeconds(timeToLiveSeconds));
            }
            

        }

        private static string GenerateCacheKeyFromRequest(HttpRequest request)
        {
            var keyBuilder = new StringBuilder();

            keyBuilder.Append($"{request.Path}");

            foreach(var (key,value) in request.Query.OrderBy(x => x.Key))
            {
                keyBuilder.Append($"|{key}-{value}");
            }

            return keyBuilder.ToString();
        }
    }
}
