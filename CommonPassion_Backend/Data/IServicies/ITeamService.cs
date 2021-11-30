using CommonPassion_Backend.Data.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CommonPassion_Backend.Data.ApiModels.ApiTeam;

namespace CommonPassion_Backend.Data.IServicies
{
    public interface ITeamService
    {
        public Task<ApiTeam> GetTeamInfo(int teamId);
        public Task<ApiTeamSeason> GetTeamStats(int leagueId, int season, int teamId);
        public Task<ApiAvaialbleSeasons> GetTeamSeasons(int teamId);
        public Task<ApiTeam> GetTeamsFromLeague(int leagueId, int season);
    }
}
