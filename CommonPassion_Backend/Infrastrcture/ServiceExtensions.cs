using CommonPassion_Backend.Data.IServicies;
using CommonPassion_Backend.Data.Servicies;
using CommonPassion_Backend.Entities;
using CommonPassion_Backend.IServicies;
using CommonPassion_Backend.Migrations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                AddTransient<IPlayerStanding, PlayerStanding>().
                AddTransient<IFixtureService, FixtureService>().
                AddTransient<ICoachService, CoachService>();
                
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


    }
}
