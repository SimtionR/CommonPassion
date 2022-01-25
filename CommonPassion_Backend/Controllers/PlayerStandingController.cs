using CommonPassion_Backend.Data.ApiModels;
using CommonPassion_Backend.Data.IServicies;
using CommonPassion_Backend.Infrastrcture;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Controllers
{
    [Cache(3600)]
    public class PlayerStandingController : ApiController
    {
        private readonly IPlayerStandingService playerStandingService;

        public PlayerStandingController(IPlayerStandingService playerStandingService)
        {
            this.playerStandingService = playerStandingService;
        }

        [HttpGet]
        [Route("scorers/{leagueId}/{season?}")]
        public async Task<ActionResult<ApiPlayerStanding>> GetTopScorersFromLeague(int leagueId, int season = Constants.CURRENT_SEASON)
        {
            var scorers = await this.playerStandingService.GetTopScorersFromLeague(leagueId, season);

            return scorers;
        }


        [HttpGet]
        [Route("mostAssists/{leagueId}/{season?}")]
        public async Task<ActionResult<ApiPlayerStanding>> GetAssistsTopFromLeague(int leagueId, int season = Constants.CURRENT_SEASON)
        {
            var assists = await this.playerStandingService.GetTopAssistsFromleague(leagueId, season);

            return assists;
        }

        [HttpGet]
        [Route("yellowCards/{leagueId}/{season?}")]
        public async Task<ActionResult<ApiPlayerStanding>> GetMostYellowCardsFromLeague(int leagueId, int season = Constants.CURRENT_SEASON)
        {
            var yellowCards = await this.playerStandingService.GetMostYellowCardsFromLeague(leagueId, season);

            return yellowCards;
        }
        [HttpGet]
        [Route("redCards/{leagueId}/{season?}")]
        public async Task<ActionResult<ApiPlayerStanding>> GetMostRedCardsFromLeague(int leagueId, int season = Constants.CURRENT_SEASON)
        {
            var redCards = await this.playerStandingService.GetMostRedCardsFromLeague(leagueId, season);
            return redCards;

        }

    }
}

