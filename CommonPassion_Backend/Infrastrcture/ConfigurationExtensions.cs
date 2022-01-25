using CommonPassion_Backend.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Infrastrcture
{
    public static class ConfigurationExtensions
    {
        public static string GetDefaultConnectionString(this IConfiguration configuration)
            => configuration.GetConnectionString("DefaultConnection");

        public static AppSettings GetAppSetings(this IConfiguration configuration, IServiceCollection services)
        {
            var applicationSettingsConfiguration = configuration.GetSection("ApplicationSettings");
            services.Configure<AppSettings>(applicationSettingsConfiguration);
            var appSettings = applicationSettingsConfiguration.Get<AppSettings>();

            return appSettings;

        }

        public static ApiConfigSettings GetApiConfigSettings(this IConfiguration configuration, IServiceCollection services)
        {
            var apiConfigSettings = configuration.GetSection("ApiSettings");
            services.Configure<ApiConfigSettings>(apiConfigSettings);
            var apiSettings = apiConfigSettings.Get<ApiConfigSettings>();

            return apiSettings;
        }
    }

    
}
