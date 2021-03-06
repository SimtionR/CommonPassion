using CommonPassion_Backend.Data.ApiModels;
using CommonPassion_Backend.Data.IServicies;
using CommonPassion_Backend.Infrastrcture;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Controllers
{
    [Cache(3600)]
    public class FixturesController : ApiController
    {
        private readonly IFixtureService _fixtureService;
        public string CURRENT_DATE = DateTime.Now.ToString("yyyy-MM-dd");

        public FixturesController(IFixtureService fixtureService)
        {
            _fixtureService = fixtureService;
        }

        [HttpGet]
        [Route("today/leagueId/{leagueId}")]
        public async Task<ActionResult<ApiFixture>> GetTodayFixturesByLeague( int leagueId)
        {
            var fixtures = await this._fixtureService.GetTodayFixturesFromLeague(leagueId, CURRENT_DATE, Constants.CURRENT_SEASON);
            return checkedFixtures(fixtures);

        }



        [HttpGet]
        [Route("leagueId/{leagueId}/round/{round}/{season?}")]

        public async Task<ActionResult<ApiFixture>> GetFixturesByLeagueRound(int leagueId, int round, int season = Constants.CURRENT_SEASON)
        {
            var fixtures = await this._fixtureService.GetFixturesByLeagueRound(leagueId, round, season);
            return checkedFixtures(fixtures);

        }


        [HttpGet]
        [Route("teamId/{teamId}/{season?}")]
        public async Task<ActionResult<ApiFixture>> GetFixturesByTeam(int teamId, int season = Constants.CURRENT_SEASON)
        {
            var fixtures = await this._fixtureService.GetFixturesByTeam(teamId, season);
            return checkedFixtures(fixtures);
        }

        [HttpGet]
        [Route("home")]
        public async Task<IEnumerable<ApiFixture>> GetAllLiveImportantFixtures()
        {
            var fixtures = await this._fixtureService.GetAllLiveImportantFixtures();
            if (fixtures != null)
                return fixtures;

            else return (IEnumerable<ApiFixture>)NotFound();
        }
        
        [HttpGet]
        [Route("h2h/{teamId1}/{teamId2}")]
        public async Task<ActionResult<ApiFixture>> GetH2HFixtures(int teamId1, int teamId2)
        {
            var fixtures = await this._fixtureService.GetH2HFixtures(teamId1, teamId2);
            return checkedFixtures(fixtures);
        }

        [HttpGet]
        [Route("fixtureStats/{fixtureId}")]
        public async Task<ActionResult<ApiFixture>> GetFixtureStats(string fixtureId)
        {
            var fixtures = await this._fixtureService.GetFixtureStats(fixtureId);
            return checkedFixtures(fixtures);
        }

        [HttpGet]
        [Route("next/{nbFixtures}/teamId/{teamId}")]
        public async Task<ActionResult<ApiFixture>> GetNextClubFixtures(int nbFixtures, int teamId)
        {
            var fixtures = await this._fixtureService.GetNextClubFixtures(nbFixtures, teamId);
            return checkedFixtures(fixtures);
        }

        [HttpGet]
        [Route("last/{nbFixtures}/teamId/{teamId}")]
        public async Task<ActionResult<ApiFixture>> GetLastClubFixtures(int nbFixtures, int teamId)
        {
            var fixtures = await this._fixtureService.GetLastClubFixtures(nbFixtures, teamId);
            return checkedFixtures(fixtures);
        }

        [HttpGet]
        [Route("leagueId/{leagueId}")]
        public async Task<ActionResult<ApiFixture>> GetFixturesByLeague(int leagueId, int season = Constants.CURRENT_SEASON)
        {
            var fixtures = await this._fixtureService.GetFixturesByLeague(leagueId, season);
            return checkedFixtures(fixtures);
        }


        private ActionResult<T> checkedFixtures<T>(T fixtures)
        {
            if (fixtures != null)
                return fixtures;


            else return NotFound();
        }



    }
}
