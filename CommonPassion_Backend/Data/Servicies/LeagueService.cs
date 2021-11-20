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
                RequestUri = new Uri("https://api-football-v1.p.rapidapi.com/v3/leagues"),
                Headers =
                        {
                            { "x-rapidapi-host", "api-football-v1.p.rapidapi.com" },
                            { "x-rapidapi-key", "***REMOVED***" },
                        }
            };
        }
        public async Task<ApiLeague> GetAllLeagues()
        {
          
            using (var respone = await _httpClient.SendAsync(_requestMessage))
            {
                respone.EnsureSuccessStatusCode();
                var leagues = await respone.Content.ReadFromJsonAsync<ApiLeague>();

                return leagues;
                
            }         
        }

        public async Task<ApiLeague> GetLeagueaById(int id)
        {
            ChangeRequestMessageLeagueId(id);
            return await returnLeague();
        }

       
        public async Task<ApiLeague> GetLeagueByCountry(string country)
        {
            ChangeRequestMessageCountryCode(country);
            return await returnLeague();
          
        }

        public async Task<ApiLeague> GetLeagueByTeamId(int id)
        {
            ChangeRequestMessageTeamId(id);
            return await returnLeague();
        }

        //Changes the req message 
        private void ChangeRequestMessageLeagueId(int id)
        {
            this._requestMessage.RequestUri = new Uri($"https://api-football-v1.p.rapidapi.com/v3/leagues?id={id}");

        }


        private void ChangeRequestMessageTeamId(int id)
        {
            this._requestMessage.RequestUri = new Uri($"https://api-football-v1.p.rapidapi.com/v3/leagues?team={id}");

        }


        private void ChangeRequestMessageCountryCode(string code)
        {
            this._requestMessage.RequestUri = new Uri($"https://api-football-v1.p.rapidapi.com/v3/leagues?code={code}");

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
