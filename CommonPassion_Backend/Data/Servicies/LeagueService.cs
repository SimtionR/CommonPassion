using CommonPassion_Backend.Data.ApiModels;
using CommonPassion_Backend.Data.Entities;
using CommonPassion_Backend.Data.IServicies;
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



                return await returnLeague();
                
            
        }

        public async Task<ApiLeague> GetLeagueaById(int id,string current)
        {
            ChangeRequestMessageLeagueId(id,current);
            return await returnLeague();
        }

       
        public async Task<ApiLeague> GetLeagueByCountry(string country, string current)
        {
            ChangeRequestMessageCountryCode(country, current);
            return await returnLeague();
          
        }

        public async Task<ApiLeague> GetLeagueByTeamId(int id, string current)
        {
            ChangeRequestMessageTeamId(id,current);
            return await returnLeague();
        }


      





        //Changes the req message 
        private void ChangeRequestMessageLeagueId(int id, string current)
        {
            
            this._requestMessage.RequestUri = new Uri($"https://api-football-v1.p.rapidapi.com/v3/leagues?id={id}&current={current}");

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
        private async Task<ApiLeague> returnLeague()
        {
            using (var response = await _httpClient.SendAsync(_requestMessage))
            {
                response.EnsureSuccessStatusCode();
                var league = await response.Content.ReadFromJsonAsync<ApiLeague>();

                return league;
            }
        }

        
    }
}
