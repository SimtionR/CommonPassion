using CommonPassion_Backend.Data.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.IServicies
{
    public interface IPlayerStanding
    {
        public Task<ApiPlayerStanding> GetTopScorersFromLeague(int leagueId, int season);
        public Task<ApiPlayerStanding> GetTopAssistsFromleague(int leagueId, int season);
        public Task<ApiPlayerStanding> GetMostYellowCardsFromLeague(int leagueId, int season);
        public Task<ApiPlayerStanding> GetMostRedCardsFromLeague(int leagueId, int season);

    }
}
