using CommonPassion_Backend.Data.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.IServicies
{
    public interface IPlayerService
    {
        public Task<ApiPlayer> GetAllStatsAvaialbe();
        public Task<ApiPlayer> GetPlayerStats(int playerId, int season);
        public Task<ApiPlayerGame> GetPlayersGameStats(int fixture);
        public Task<ApiPlayerLeague> GetPlayersStatsByLeague(int leagueId, int season);
        public Task<ApiPlayer> GetPlayersStatsByTeam(int teamId, int season);
        public Task<ApiPlayer> GetPlayerAllStats(int playerId);
        
    }
}
