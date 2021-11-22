using CommonPassion_Backend.Data.ApiModels;
using CommonPassion_Backend.Data.IServicies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        [HttpGet]
        [Route("id={id}&&season={season}")]
        public async Task<ActionResult<ApiPlayer>> GetPlayerStatsById(int id, int season)
        {
            var player = await _playerService.GetPlayerStats(id, season);
            return playerChecked(player);
        }

       

        [HttpGet]
        [Route("game={gameId}")]
        public async Task<ActionResult<ApiPlayerGame>> GetPlayersStatsByGame(int gameId)
        {
            var player = await this._playerService.GetPlayersGameStats(gameId);
            return  playerChecked(player);
            
        }


        [HttpGet]
        [Route("league={leagueId}&&season={season}")]
        public async Task<ActionResult<ApiPlayerLeague>> GetPlayersFromLeague(int leagueId, int season)
        {
            var player = await this._playerService.GetPlayersStatsByLeague(leagueId, season);
            return playerChecked<ApiPlayerLeague>(player);

        }

        [HttpGet]
        [Route("test")]
        public async Task<string> test()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://api-football-v1.p.rapidapi.com/v3/fixtures/players?fixture=169080"),
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

        [HttpGet]
        [Route("team={teamId}&&season={season}")]
        public async Task<ActionResult<ApiPlayer>> GetPlayersFromTeam(int teamId, int season)
        {

            var player = await this._playerService.GetPlayersStatsByTeam(teamId, season);
            return playerChecked(player);

        }


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
