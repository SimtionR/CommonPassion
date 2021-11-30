using CommonPassion_Backend.Data.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.IServicies
{
    public interface IStandingSerivce
    {
        public Task<ApiStanding> GetStandingByLeague(int leagueId, int season);
        public Task<ApiStanding> GetStandingByTeam(int teamId, int season);
    }
}
