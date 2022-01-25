using CommonPassion_Backend.Data.ApiModels;
using CommonPassion_Backend.Data.IServicies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Controllers
{
    [Cache(3600)]
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
        [Route("{id}/{current?}")]


        public async Task<ActionResult<ApiLeague>> GetLeagueById(int id, string current = "false")
        {
            var league = await this._leagueService.GetLeagueaById(id, current);
            return Result(league);
        }



        //gets league by club Id

        [HttpGet]
        [Route("clubId/{id}/{current?}")]
        public async Task<ActionResult<ApiLeague>> GetLeagueByTeamId(int id, string current="false") //ramane de vazut 
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

 


        [HttpGet]
        [Route("home")]
        public async Task<IEnumerable<ApiLeague>> GetImprotantLeagues()
        {
            var leagues = await this._leagueService.GetTop5_1Leagues();

            if (leagues.Count() > 0)
            {
                return leagues;
            }
            else return (IEnumerable<ApiLeague>)NotFound();

           
        }


        [HttpGet]
        [Route("country/{countryName}")]
        public async Task<ActionResult<ApiLeague>> GetLeagueByCountryName(string countryName)
        {
            var league = await this._leagueService.GetLeagueByCountryName(countryName);
            return Result(league);
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
