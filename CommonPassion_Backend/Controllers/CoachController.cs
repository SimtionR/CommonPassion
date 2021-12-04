using CommonPassion_Backend.Data.ApiModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Controllers
{
    public class CoachController : ApiController
    {
        [HttpGet]
        [Route("teamId/{teamId}")]
        public async Task<ApiCoach> GetCoachByTeamId(int teamId)
        {

        }


        [HttpGet]
        [Route("/name/{coachName}")]
        public async Task<ApiCoach> GetCoachByName(string coachName)
        {

        }


        [HttpGet]
        [Route("test")]
        public async  Task<string> Test()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://api-football-v1.p.rapidapi.com/v3/coachs?team=33"),
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
    }
}
