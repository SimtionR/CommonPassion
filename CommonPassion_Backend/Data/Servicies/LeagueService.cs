using CommonPassion_Backend.Data.ApiModels;
using CommonPassion_Backend.Data.IServicies;
using CommonPassion_Backend.Data.Models.Request;
using CommonPassion_Backend.Infrastrcture;
using CommonPassion_Backend.Settings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.Servicies
{
    public class LeagueService : ILeagueService
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<ApiConfigSettings> _apiSettings;
        private readonly HttpRequestMessage _requestMessage;

        public LeagueService(HttpClient httpClient, IOptions<ApiConfigSettings> apiSettings)
        {
            _httpClient = httpClient;
            _apiSettings = apiSettings;
            _requestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                
                Headers =
                        {
                            { "x-rapidapi-host", apiSettings.Value.ApiHost },
                            { "x-rapidapi-key", apiSettings.Value.ApiKey },
                        }
            };
        }
        public async Task<ApiLeague> GetAllLeagues(string current)
        {
          
           
                this._requestMessage.RequestUri = new Uri($"https://api-football-v1.p.rapidapi.com/v3/leagues");



                return await returnLeague(_requestMessage);
                
            
        }

        public async Task<ApiLeague> GetLeagueaById(int id, string current)
        {
            ChangeRequestMessageLeagueId(id, current);
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

        public async Task<IEnumerable<ResponseLeague>> GetImportantLeaguesTest()
        {

            int[] leaguesChcked = new int[] { 39, 135, 140, 61, 78, 283};


            this._requestMessage.RequestUri = new Uri("https://api-football-v1.p.rapidapi.com/v3/leagues?current=true");
            using(var resposne = await this._httpClient.SendAsync(this._requestMessage))
            {
                resposne.EnsureSuccessStatusCode();
                var responseApi = await resposne.Content.ReadFromJsonAsync<ApiLeague>();

                var leagues = responseApi.response.Where(l => leaguesChcked.Contains(l.league.id)).OrderByDescending(l=>l.league.name);

                return leagues;
            }
         
        }

        public async Task<IEnumerable<ApiLeague>> GetTop5_1Leagues()
        {
            var currentFalse = "false";
            var currentTrue = "true";

            var topLeagues = new ApiLeague[6];

            //bpl
            var reqBpl = await ChangeMultipleRequestMessageLeagueId(39, currentTrue);
            topLeagues[0] = await returnLeague(reqBpl);
            //serie a
            var reqSerieA = await ChangeMultipleRequestMessageLeagueId(135, currentTrue);
            topLeagues[1] = await returnLeague(reqSerieA);
            //la liga
            var reqLaLiga = await ChangeMultipleRequestMessageLeagueId(140, currentTrue);
            topLeagues[2] = await returnLeague(reqLaLiga);
            //ligue 1
            var reqLigue1 = await ChangeMultipleRequestMessageLeagueId(61, currentTrue);
            topLeagues[3] = await returnLeague(reqLigue1);
            //bundesliga id 78
            var reqBundesliga = await ChangeMultipleRequestMessageLeagueId(78, currentTrue);
            topLeagues[4] = await returnLeague(reqBundesliga);
            //liga 1
            var reqLiga1 = await ChangeMultipleRequestMessageLeagueId(283, currentTrue);
            topLeagues[5] = await returnLeague(reqLiga1);
            return topLeagues;

        }

   

        public async Task<ApiLeague> GetLeagueByCountryName(string name)
        {
            this._requestMessage.RequestUri = new Uri($"https://api-football-v1.p.rapidapi.com/v3/leagues?search={name}");

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

        
    }
}
