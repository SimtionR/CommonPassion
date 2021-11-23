
using CommonPassion_Backend.Data.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.IServicies
{
    public interface IPlayerService
    {
        // ????
        public Task<ApiPlayer> GetAllStatsAvaialbe();
        //used
        public Task<ApiPlayer> GetPlayerStats(int playerId, int season);
        //used
        public Task<ApiPlayer> GetPlayersGameStats(int fixture);
        //used
        public Task<ApiPlayer> GetPlayersStatsByLeague(int leagueId, int season);
        //used
        public Task<ApiPlayer> GetPlayersStatsByTeam(int teamId, int season);
        //used -???? 
        public Task<ApiPlayer> GetPlayerAllStats(int playerId);

        //used
        public Task<ApiPlayer> GetPlayerByName(string playerName, int teamId, int leagueId, int season);


    }
}
