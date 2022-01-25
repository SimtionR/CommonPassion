using CommonPassion_Backend.Data.ApiModels;
using CommonPassion_Backend.Data.IServicies;
using CommonPassion_Backend.Infrastrcture;
using CommonPassion_Backend.Settings;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.Servicies
{
    public class StandingService : IStandingSerivce
    {
        
        private readonly HttpClient _httpClient;
        private readonly IOptions<ApiConfigSettings> _apiSettings;
        private readonly HttpRequestMessage _requestMessage;

        public StandingService( HttpClient httpClient, IOptions<ApiConfigSettings> apiSettings)
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
                },
            };
        }
        
        public async  Task<ApiStanding> GetStandingByLeague(int leagueId,int season)
        {
            season = FunctionHelper.checkingSeason(season);

            this._requestMessage.RequestUri = new Uri($"https://api-football-v1.p.rapidapi.com/v3/standings?season={season}&league={leagueId}");

            return await returnLeague();
        }

        


        public async Task<ApiStanding> GetStandingByTeam(int teamId, int season)
        {
            season = FunctionHelper.checkingSeason(season);
            this._requestMessage.RequestUri = new Uri($"https://api-football-v1.p.rapidapi.com/v3/standings?season={season}&team={teamId}");
            return await returnLeague();
        }


        

        private async Task<ApiStanding> returnLeague()
        {
            using (var response = await this._httpClient.SendAsync(this._requestMessage))
            {
                response.EnsureSuccessStatusCode();
                var standing = await response.Content.ReadFromJsonAsync<ApiStanding>();
                return standing;
            }
        }
    }
}
