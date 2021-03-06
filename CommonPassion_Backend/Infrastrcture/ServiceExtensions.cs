using CommonPassion_Backend.Data.IServicies;
using CommonPassion_Backend.Data.Servicies;
using CommonPassion_Backend.Data.Entities;
using CommonPassion_Backend.IServicies;
using CommonPassion_Backend.Migrations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using CommonPassion_Backend.Settings;
using CommonPassion_Backend.Data.Servicies.BlobService;

namespace CommonPassion_Backend.Infrastrcture
{
    public static class ServiceExtensions
    {

        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {
            return services.
                AddTransient<IUserService, UserService>().
                AddTransient<ILeagueService, LeagueService>().
                AddTransient<ITeamService, TeamService>().
                AddTransient<IPlayerService, PlayerService>().
                AddTransient<IIdentityService, IdentityService>().
                AddTransient<IStandingSerivce, StandingService>().
                AddTransient<IPlayerStandingService, PlayerStandingService>().
                AddTransient<IFixtureService, FixtureService>().
                AddTransient<ICoachService, CoachService>().
                AddTransient<IConnectionService, ConnectionService>().
                AddTransient<IProfileService, ProfileService>().
                AddScoped<IBlobStorageService, BlobStorageService>().
                AddTransient<IReactionService, ReactionService>().
                AddTransient<IUserReviewService, UserReviewService>().
                AddTransient<ILeagueDetailsService, LeagueDetailsService>();
                
                
                
        }

        public static IServiceCollection AddIdentity( this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 5;

            })
               .AddEntityFrameworkStores<CommonPassionDbContext>() ;

                return services;
        }

        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, AppSettings appSettings)
        {

            var key = Encoding.ASCII.GetBytes(appSettings.Secret);


            services
                .AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false

                    };
                });
            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CommonPassion ", Version = "v1" });
                c.CustomSchemaIds(type => type.ToString());
            });

            return services;
        }

       public static IServiceCollection AddCache(this IServiceCollection services, IConfiguration configuration)
        {
            var redisCacheSettings = new RedisCacheSettings();
            configuration.GetSection(nameof(RedisCacheSettings)).Bind(redisCacheSettings);
            services.AddSingleton(redisCacheSettings);

            if(!redisCacheSettings.Enabled)
            {
                return services; 
            }

            services.AddStackExchangeRedisCache(options => options.Configuration = redisCacheSettings.ConnectionString);
            services.AddSingleton<IResponseCacheService, ResponseCacheService>();
           
            return services;
        }


    }
}
