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
    public class StandingController : ApiController
    {

        private readonly IStandingSerivce _standingSerivce;

        public StandingController(IStandingSerivce standingSerivce)
        {
            _standingSerivce = standingSerivce;
        }
        [HttpGet]
        [Route("team/{teamId}/{season?}")]
        public async Task<ActionResult<ApiStanding>> GetStandingByTeam(int teamId, int season=Constants.CURRENT_SEASON)
        {
            var standing = await this._standingSerivce.GetStandingByTeam(teamId, season);
            return returnStanding(standing);

            /*var testStanding = standing.response[0].league.standings.Where(s => s.Rank == 1).FirstOrDefault();
            return testStanding;*/
        }

        [HttpGet]
        [Route("league/{leagueId}/{season?}")]
        public async Task<ActionResult<ApiStanding>> GetStandingByLeague(int leagueId, int season=Constants.CURRENT_SEASON)
        {
            var standing = await this._standingSerivce.GetStandingByLeague(leagueId, season);
            return returnStanding(standing);
        }



        private ActionResult<ApiStanding> returnStanding(ApiStanding standing)
        {
            if (standing != null)
                return standing;
            else
                return NotFound();
        }

        [HttpGet]
        [Route("test")]
        public async Task<ActionResult<string>> Test()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://api-football-v1.p.rapidapi.com/v3/standings?season=2021&league=140&team=529"),
                Headers =
    {
        { "x-rapidapi-host", "api-football-v1.p.rapidapi.com" },
        { "x-rapidapi-key", "***REMOVED***" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);

                return body;
            }
        }
    }
}
