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

       
    }
}
