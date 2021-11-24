using CommonPassion_Backend.Data.ApiModels;
using CommonPassion_Backend.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.IServicies
{
    public interface ILeagueService
    {
        public Task<ApiLeague> GetAllLeagues(string curent);
        public Task<ApiLeague> GetLeagueaById(int id, string current);
        public Task<ApiLeague> GetLeagueByCountry(string country, string current);
        public Task<ApiLeague> GetLeagueByTeamId(int id, string current);


        //public Task<ApiLeague> GetRunningLeagues();
    }
}
