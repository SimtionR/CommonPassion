using CommonPassion_Backend.Data.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.IServicies
{
    public interface IFixtureService
    {
        Task<ApiFixture> GetTodayFixturesFromLeague(int leagueId, string date, int season);
        Task<ApiFixture> GetFixturesByLeagueRound(int leagueId, int round, int season);
        Task<ApiFixture> GetFixturesByTeam(int teamId, int season);
        Task<ApiFixture> GetH2HFixtures(int teamId1, int teamId2);

        Task <IEnumerable<ApiFixture>> GetAllLiveImportantFixtures();
        Task<ApiFixture> GetNextClubFixtures(int nbFixtures, int teamId);

        Task<ApiFixture> GetFixtureStats(string fixtureId);
        Task<ApiFixture> GetLastClubFixtures(int nbFixtures, int teamId);
        Task<ApiFixture> GetFixturesByLeague(int leagueId, int season);
    }
}
