using CommonPassion_Backend.Data.ApiModels;
using CommonPassion_Backend.Data.Entities;
using CommonPassion_Backend.Data.IServicies;
using CommonPassion_Backend.Data.Models.League;
using CommonPassion_Backend.Data.Processors;
using CommonPassion_Backend.Domain;
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
        

        public async Task<ActionResult<ApiLeague>> GetLeagueById(int id, string current="false")
        {
            var league = await this._leagueService.GetLeagueaById(id,current);
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

       /* [HttpGet]
        [Route("runningSeasons")]
        public async Task<ActionResult<ApiLeague>> GetRunningSeasons()
        {

        }*/


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


        //testing 
        [HttpGet]
        [Route("leagueById/ReqObject/{leagueId}")]
        public async Task<ActionResult<LeagueResponseModel>> GetLeagueByReqLeagueId(int leagueId)
        {
            var requestLeague = await this._leagueService.GetLeagueByReqLeagueId(leagueId);
            if (requestLeague == null)
                return NotFound();


            /*  var league = new LeagueModel
              {
                  league = new Domain.League
                  {
                      id = requestLeague.response[0].league.id,
                      name = requestLeague.response[0].league.name,
                      logo = requestLeague.response[0].league.logo,
                      type = requestLeague.response[0].league.type
                  },


                  seasons = (Domain.Season[])requestLeague.response[0].seasons.Select(x => new Domain.Season { current = x.current, end = x.end, start = x.start, year = x.year })

              };
  */
            var league = new Domain.LeagueModel
            {
                paging = new Domain.LeagueModel.Paging { current = requestLeague.paging.current, total = requestLeague.paging.total },
                parameters = new Domain.LeagueModel.Parameters { id = requestLeague.parameters.id },
                response = new Domain.LeagueModel.Response[]
                {
                   new LeagueModel.Response
                   {
                       country = new Domain.LeagueModel.Country
                       {
                           code = requestLeague.response[0].country.code,
                           flag = requestLeague.response[0].country.flag,
                           name = requestLeague.response[0].country.name
                       },

                       league = new Domain.LeagueModel.League
                       {
                           id = requestLeague.response[0].league.id,
                           logo = requestLeague.response[0].league.logo,
                           name = requestLeague.response[0].league.name,
                           type =  requestLeague.response[0].league.type
                       },
                       seasons = (LeagueModel.Season[])requestLeague.response[0].seasons.Select( x=> new Domain.LeagueModel.Season
                       {
                           current = x.current,
                           end = x.end,
                           start = x.start,
                           year = x.year 
                       })
  
                   }
                }
                
              
            };


            var responseLeague = new LeagueResponseModel
            {
                paging = new LeagueResponseModel.Paging { current = league.paging.current, total = league.paging.total },
                parameters = new LeagueResponseModel.Parameters { id = league.parameters.id },
                response = new LeagueResponseModel.Response[]
                {
                    new LeagueResponseModel.Response
                    {
                        country = new LeagueResponseModel.Country
                        {
                            code = requestLeague.response[0].country.code,
                            flag = requestLeague.response[0].country.flag,
                            name = requestLeague.response[0].country.name
                        },

                        league = new LeagueResponseModel.League
                        {

                            id = requestLeague.response[0].league.id,
                            logo = requestLeague.response[0].league.logo,
                            name = requestLeague.response[0].league.name,
                            type = requestLeague.response[0].league.type
                        },
                        seasons = (LeagueResponseModel.Season[])requestLeague.response[0].seasons.Select(x => new LeagueResponseModel.Season
                        {
                            start = x.start,
                            end = x.end,
                            year = x.year,
                            current = x.current
                        })


                    }

                }
            };

            return responseLeague;
                
        }

       



        [HttpGet]
        [Route("test")]
        public async Task<ActionResult<string>> GetTested()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://api-football-v1.p.rapidapi.com/v3/leagues"),
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
