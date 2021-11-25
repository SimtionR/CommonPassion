using CommonPassion_Backend.Data.ApiModels;
using CommonPassion_Backend.Data.Entities;
using CommonPassion_Backend.Data.IServicies;
using CommonPassion_Backend.Infrastrcture;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.Servicies
{
    public class LeagueService : ILeagueService
    {
        private readonly HttpClient _httpClient;
        private readonly HttpRequestMessage _requestMessage;

        public LeagueService(HttpClient httpClient)
        {
            _httpClient = httpClient;

            _requestMessage= new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                
                Headers =
                        {
                            { "x-rapidapi-host", "api-football-v1.p.rapidapi.com" },
                            { "x-rapidapi-key", "***REMOVED***" },
                        }
            };
        }
        public async Task<ApiLeague> GetAllLeagues(string current)
        {
          
           
                this._requestMessage.RequestUri = new Uri($"https://api-football-v1.p.rapidapi.com/v3/leagues?current={current}");



                return await returnLeague(_requestMessage);
                
            
        }

        public async Task<ApiLeague> GetLeagueaById(int id,string current)
        {
            ChangeRequestMessageLeagueId(id,current);
            return await returnLeague(_requestMessage);
        }

       
        public async Task<ApiLeague> GetLeagueByCountry(string country, string current)
        {
            ChangeRequestMessageCountryCode(country, current);
            return await returnLeague(_requestMessage);
          
        }

        public async Task<ApiLeague> GetLeagueByTeamId(int id, string current)
        {
            ChangeRequestMessageTeamId(id,current);
            return await returnLeague(_requestMessage);
        }








        //Changes the req message 
        private void ChangeRequestMessageLeagueId(int id, string current)
        {

            this._requestMessage.RequestUri = new Uri($"https://api-football-v1.p.rapidapi.com/v3/leagues?id={id}&current={current}");

        }

        //Change the req message multiple-call;
        private async  Task<HttpRequestMessage> ChangeMultipleRequestMessageLeagueId(int id, string current)
        {
            var newReq= await this._requestMessage.CloneAsync();
            newReq.RequestUri = new Uri($"https://api-football-v1.p.rapidapi.com/v3/leagues?id={id}&current={current}");

            return newReq;

            /*var reqMessage2 = new HttpRequestMessage();
            reqMessage2 = this._requestMessage;

           reqMessage2.RequestUri = new Uri($"https://api-football-v1.p.rapidapi.com/v3/leagues?id={id}&current={current}");

            return reqMessage2;*/

        }




        private void ChangeRequestMessageTeamId(int id, string current)
        {
            this._requestMessage.RequestUri = new Uri($"https://api-football-v1.p.rapidapi.com/v3/leagues?team={id}&current={current}");

        }


        private void ChangeRequestMessageCountryCode(string code, string current)
        {
            this._requestMessage.RequestUri = new Uri($"https://api-football-v1.p.rapidapi.com/v3/leagues?code={code}&current={current}");

        }


        //async operation  using requestMessageGet the object;
        private async Task<ApiLeague> returnLeague(HttpRequestMessage requestMessage)
        {
            using (var response = await _httpClient.SendAsync(requestMessage))
            {
                response.EnsureSuccessStatusCode();
                var league = await response.Content.ReadFromJsonAsync<ApiLeague>();

                return league;
            }
        }
     


        //JUST A TEST

        public async Task<IEnumerable<ApiLeague>> GetTop5_1Leagues()
        {
            var currentFalse = "false";
            var currentTrue = "true";

            var topLeagues = new ApiLeague[6];

            //bpl
            var reqBpl= await ChangeMultipleRequestMessageLeagueId(39, currentTrue);
            topLeagues[0] = await returnLeague(reqBpl);
            //serie a
            var reqSerieA= await ChangeMultipleRequestMessageLeagueId(135, currentTrue);
            topLeagues[1] = await returnLeague(reqSerieA);
            //la liga
            var reqLaLiga= await ChangeMultipleRequestMessageLeagueId(140, currentTrue);
            topLeagues[2] = await returnLeague(reqLaLiga);
            //ligue 1
            var reqLigue1= await ChangeMultipleRequestMessageLeagueId(61, currentTrue);
            topLeagues[3] = await returnLeague(reqLigue1);
            //bundesliga id 78
            var reqBundesliga= await ChangeMultipleRequestMessageLeagueId(78, currentTrue);
            topLeagues[4] = await returnLeague(reqBundesliga);
            //liga 1
            var reqLiga1= await ChangeMultipleRequestMessageLeagueId(283, currentTrue);
            topLeagues[5] = await returnLeague(reqLiga1);
            return topLeagues;


            
            
        }     
        
  
    }
}
