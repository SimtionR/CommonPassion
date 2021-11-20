using CommonPassion_Backend.Data.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.IServicies
{
    public interface ITeamService
    {
        public Task<ApiTeam> GetTeamInfo(int teamId);
        public Task<ApiTeam> GetTeamStats(int leagueId, int season, int teamId);
        public Task<ApiTeam> GetTeamSeasons(int teamId);
    }
}
