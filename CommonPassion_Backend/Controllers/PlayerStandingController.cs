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
    public class PlayerStandingController : ApiController
    {
        private readonly IPlayerStanding _playerStanding;

        public PlayerStandingController(IPlayerStanding playerStanding)
        {
            _playerStanding = playerStanding;
        }

        [HttpGet]
        [Route("scorers/{leagueId}/{season?}")]
        public async Task<ActionResult<ApiPlayerStanding>> GetTopScorersFromLeague(int leagueId, int season = Constants.CURRENT_SEASON)
        {
            var scorers = await this._playerStanding.GetTopScorersFromLeague(leagueId, season);

            return scorers;
        }


        [HttpGet]
        [Route("mostAssists/{leagueId}/{season?}")]
        public async Task<ActionResult<ApiPlayerStanding>> GetAssistsTopFromLeague(int leagueId, int season = Constants.CURRENT_SEASON)
        {
            var assists = await this._playerStanding.GetTopAssistsFromleague(leagueId, season);

            return assists;
        }

        [HttpGet]
        [Route("yelloeCards/{leagueId}/{season?}")]
        public async Task<ActionResult<ApiPlayerStanding>> GetMostYellowCardsFromLeague(int leagueId, int season = Constants.CURRENT_SEASON)
        {
            var yellowCards = await this._playerStanding.GetMostYellowCardsFromLeague(leagueId, season);

            return yellowCards;
        }
        [HttpGet]
        [Route("redCards/{leagueId}/{season?}")]
        public async Task<ActionResult<ApiPlayerStanding>> GetMostRedCardsFromLeague(int leagueId, int season = Constants.CURRENT_SEASON)
        {
            var redCards = await this._playerStanding.GetMostRedCardsFromLeague(leagueId, season);
            return redCards;

        }

    }
}

