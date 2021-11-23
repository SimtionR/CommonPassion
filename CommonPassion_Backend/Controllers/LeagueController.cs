using CommonPassion_Backend.Data.ApiModels;
using CommonPassion_Backend.Data.Entities;
using CommonPassion_Backend.Data.IServicies;
using CommonPassion_Backend.Data.Processors;
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
    public class LeagueController : ApiController
    {
        //private readonly IHttpClientFactory _clientFactory;
        private readonly ILeagueService _leagueService;

        public LeagueController(ILeagueService leagueService)
        {
            //_clientFactory = clientFactory;
            _leagueService = leagueService;
        }



        //Gets info about all leagueas avaialble 
        [HttpGet]
        [Route("all/{current?}")]
        public async Task<ActionResult<ApiLeague>> GetAllLeagues(string current="false")
        {
            var leagues = await _leagueService.GetAllLeagues(current);
            return Result(leagues);

        }

        //gets league by league ID 
        [HttpGet]
        [Route("id={id}/{current?}")]

        public async Task<ActionResult<ApiLeague>> GetLeagueById(int id, string current="false")
        {
            var league = await this._leagueService.GetLeagueaById(id,current);
            return Result(league);
        }



        //gets league by club Id

        [HttpGet]
        [Route("clubId={id}/{current?}")]
        public async Task<ActionResult<ApiLeague>> GetLeagueByTeamId(int id, string current="false")
        {
            var league = await this._leagueService.GetLeagueByTeamId(id, current);
            return Result(league);

        }


        //gets league by countryCode
        [HttpGet]
        [Route("countryCode={id}/{current?}")]
        public async Task<ActionResult<ApiLeague>> GetLeagueByCountryCode(string id, string current="false")
        {
            var league = await this._leagueService.GetLeagueByCountry(id, current);
            return Result(league);
        }

       /* [HttpGet]
        [Route("runningSeasons")]
        public async Task<ActionResult<ApiLeague>> GetRunningSeasons()
        {

        }*/


        [HttpGet]
        [Route("test")]
        public async Task<ActionResult<string>> GetTested()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://api-football-v1.p.rapidapi.com/v3/leagues?team=33&current=true"),
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


        private ActionResult<ApiLeague> Result(ApiLeague league)
        {
            if (league == null)
            {
                return this.NotFound();
            }
            return league;
        }


    }
}
