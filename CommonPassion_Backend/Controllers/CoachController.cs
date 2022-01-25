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
    [Cache(3600)]
    public class CoachController : ApiController
    {
        private readonly ICoachService _coachService;

        public CoachController(ICoachService coachService)
        {
            _coachService = coachService;
        }

        [HttpGet]
        [Route("teamId/{teamId}")]
        public async Task<ActionResult<ApiCoach>> GetCoachByTeamId(int teamId)
        {
            var coach = await this._coachService.GetCoachByTeamId(teamId);
            return checkedCoach(coach);
        }


        [HttpGet]
        [Route("/name/{coachName}")]
        public async Task<ActionResult<ApiCoach>> GetCoachByName(string coachName)
        {
            var coach = await this._coachService.GetCoachByName(coachName);
            return checkedCoach(coach);
        }



        private ActionResult<ApiCoach> checkedCoach(ApiCoach coach)
        {
            if (coach != null)
                return coach;
            else return NotFound();
        }


    
    }
}
