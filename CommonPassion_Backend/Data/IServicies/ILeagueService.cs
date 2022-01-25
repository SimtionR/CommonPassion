using CommonPassion_Backend.Data.ApiModels;
using CommonPassion_Backend.Data.Models.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.IServicies
{
    public interface ILeagueService
    {
        public Task<ApiLeague> GetAllLeagues(string curent);
        public Task<ApiLeague> GetLeagueaById(int id, string current);
        public Task<ApiLeague> GetLeagueByCountry(string country, string current);
        public Task<ApiLeague> GetLeagueByTeamId(int id, string current);

        public Task<IEnumerable<ApiLeague>> GetTop5_1Leagues();

        public Task<ApiLeague> GetLeagueByCountryName(string name);

        public Task<IEnumerable<ResponseLeague>> GetImportantLeaguesTest();



    }
}
