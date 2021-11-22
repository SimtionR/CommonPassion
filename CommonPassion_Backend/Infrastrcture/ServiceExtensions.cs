using CommonPassion_Backend.Data.IServicies;
using CommonPassion_Backend.Data.Servicies;
using CommonPassion_Backend.IServicies;
using Microsoft.Extensions.DependencyInjection;
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
                AddTransient<IPlayerService, PlayerService>();
        }
        
    }
}
