using CommonPassion_Backend.Data.ApiModels;
using CommonPassion_Backend.Data.IServicies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Controllers
{
    public class PlayerController : ApiController
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }


        //Player by ID and season
        [HttpGet]
        [Route("{id}&{season}")]
        public async Task<ActionResult<ApiPlayer>> GetPlayerStatsById(int id, int season)
        {
            var player = await _playerService.GetPlayerStats(id, season);
            return playerChecked(player);
        }

       
        //Stats of players by GameID
        [HttpGet]
        [Route("{gameId}")]
        public async Task<ActionResult<ApiPlayer>> GetPlayersStatsByGame(int gameId)
        {
            var player = await this._playerService.GetPlayersGameStats(gameId);
            return  playerChecked(player);
            
        }


        //Stats of  players by league and season
        [HttpGet]
        [Route("{leagueId}&{season}")]
        public async Task<ActionResult<ApiPlayer>> GetPlayersFromLeague(int leagueId, int season)
        {
            var player = await this._playerService.GetPlayersStatsByLeague(leagueId, season);
            return playerChecked<ApiPlayer>(player);

        }

 

        //stats of a team's players based on a season 
        [HttpGet]
        [Route("{teamId}&{season}")]
        public async Task<ActionResult<ApiPlayer>> GetPlayersFromTeam(int teamId, int season)
        {

            var player = await this._playerService.GetPlayersStatsByTeam(teamId, season);
            return playerChecked(player);

        }
        

        //STATS OF A PLAYER based on NAME + LEAGUE/TEAM + (OPTIONAL ? Season ) 
        [HttpGet]
        [Route("{playerName}/{teamId}&{leagueId}&{season}")]
        public async Task<ActionResult<ApiPlayer>> GetPlayerByName(string playerName, int teamId=0, int leagueId=0, int season=0)
        {
            if (teamId == 0 && leagueId == 0)
                return BadRequest("One of teamId/ leagueId is required for the search");
            else
            {
                var player = await this._playerService.GetPlayerByName(playerName, teamId, leagueId, season);

                return playerChecked(player);
            }
          
        }




        //Could change with function from functionHelper
        private ActionResult<T> playerChecked<T>(T player)
        {
            if (player != null)
                return player;
            else return NotFound();
        }


        private ActionResult<T> returnPlayer<T>(T player)
        {
            if (player != null)
                return player;
            else return NotFound();
        }



    }
}
