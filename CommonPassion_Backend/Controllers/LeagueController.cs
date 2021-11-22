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


        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<ApiLeague>> GetAllLeagues()
        {
            var leagues = await _leagueService.GetAllLeagues();
            return Result(leagues);

        }


        [HttpGet]
        [Route("id={id}")]

        public async Task<ActionResult<ApiLeague>> GetLeagueById(int id)
        {
            var league = await this._leagueService.GetLeagueaById(id);
            return Result(league);
        }



        [HttpGet]
        [Route("clubId/{id}")]
        public async Task<ActionResult<ApiLeague>> GetLeagueByTeamId(int id)
        {
            var league = await this._leagueService.GetLeagueByTeamId(id);
            return Result(league);

        }

        [HttpGet]
        [Route("countryCode/{id}")]
        public async Task<ActionResult<ApiLeague>> GetLeagueByCountryCode(string id)
        {
            var league = await this._leagueService.GetLeagueByCountry(id);
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
