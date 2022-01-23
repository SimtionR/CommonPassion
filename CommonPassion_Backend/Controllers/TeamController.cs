
using CommonPassion_Backend.Data.ApiModels;
using CommonPassion_Backend.Data.IServicies;
using CommonPassion_Backend.Infrastrcture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;using static CommonPassion_Backend.Data.ApiModels.ApiTeam;

namespace CommonPassion_Backend.Controllers
{
    [Cache(3600)]
    public class TeamController : ApiController
    {
        private readonly ITeamService _teamService;

        private ApiTeam responseTeam;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
          
           
        }

        //gets team info based on id

        [HttpGet]
        [Route("{id}")]

        //Used to be <ApiTeam> 
        public async Task<ActionResult<ResponseTeam>> TeamById(int id)
        {
            /*var team = await _teamService.GetTeamInfo(id);

            return returnTeam<ApiTeam>(team);*/

            var teams = await this._teamService.GetTeamInfo2(id);

            var team = teams.response.Where(t => t.team.id == id).FirstOrDefault();

            return team;


        }

        //stats of the team based on season 
        [HttpGet]
        [Route("stats/{id}&{leagueId}/{season?}")]
        public async Task<ActionResult<ApiTeamSeason>> TeamStatsById(int id, int leagueId, int season=Constants.CURRENT_SEASON)
            {
            var team = await this._teamService.GetTeamStats(leagueId, season, id);

            return returnTeam<ApiTeamSeason>(team);
        }


        //all avaialble seasons of a team  based on teamID
        [HttpGet]
        [Route("allSeasons/{id}")]
        public async Task<ActionResult<ApiAvaialbleSeasons>> TeamSeasons(int id)
        {
            var team = await this._teamService.GetTeamSeasons(id);
            return returnTeam<ApiAvaialbleSeasons>(team);

        }

        [HttpGet]
        [Route("byLeague/{leagueId}/{season?}")]
        public async Task<ActionResult<ApiTeam>> GetTeamByLeauge(int leagueId, int season= Constants.CURRENT_SEASON)
        {
            var teams = await this._teamService.GetTeamsFromLeague(leagueId, season);
            return returnTeam<ApiTeam>(teams);
        }







        [HttpGet]
        [Route("Test")]
        public async Task<ActionResult<string>> Test()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://api-football-v1.p.rapidapi.com/v3/players/topscorers?league=39&season=2020"),
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



       




       

        private ActionResult<T> returnTeam<T>(T team)
        {
            if (team != null)
                return team;
            else return NotFound();
        }
    }
}
