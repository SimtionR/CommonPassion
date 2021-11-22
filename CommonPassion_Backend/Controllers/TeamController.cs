using CommonPassion_Backend.Data.ApiModels;
using CommonPassion_Backend.Data.IServicies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Controllers
{
    public class TeamController : ApiController
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        [Route("id={id}")]
        public async Task<ActionResult<ApiTeam>> TeamById(int id )
        {
            var team = await _teamService.GetTeamInfo(id);

            return returnTeam<ApiTeam>(team);

        }
        [HttpGet]
        [Route("stats/id={id}&&leagueId={leagueId}&&season={season}")]
        public async Task<ActionResult<ApiTeamStats>> TeamStatsById(int id, int leagueId, int season)
        {
            var team = await this._teamService.GetTeamStats(leagueId, season, id);

            return returnTeam<ApiTeamStats>(team);
        }

        [HttpGet]
        [Route("allSeasons/id={id}")]
        public async Task<ActionResult<ApiAvaialbleSeasons>> TeamSeasons( int id)
        {
            var team = await this._teamService.GetTeamSeasons(id);
            return returnTeam<ApiAvaialbleSeasons>(team);

        }


       




       

        private ActionResult<T> returnTeam<T>(T team)
        {
            if (team != null)
                return team;
            else return NotFound();
        }
    }
}
