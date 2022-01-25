using CommonPassion_Backend.Data.ApiModels;
using CommonPassion_Backend.Data.IServicies;
using CommonPassion_Backend.Settings;
using Microsoft.Extensions.Configuration;
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
    public class CoachService : ICoachService
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<ApiConfigSettings> apiSettings;
        private readonly HttpRequestMessage _requestMessage;

        public CoachService(HttpClient httpClient, IOptions<ApiConfigSettings> apiSettings )
        {
            _httpClient = httpClient;
            this.apiSettings = apiSettings;
            _requestMessage =new HttpRequestMessage
            {
                Method = HttpMethod.Get,
               
                Headers =
    {
                    { "x-rapidapi-host", apiSettings.Value.ApiHost },
                    { "x-rapidapi-key",  apiSettings.Value.ApiKey },
    },
            };
        }
        
        public async Task<ApiCoach> GetCoachByName(string coachName)
        {
            this._requestMessage.RequestUri = new Uri($"https://api-football-v1.p.rapidapi.com/v3/coachs?search={coachName}");
            return await readCoach();
        }

        

        public async Task<ApiCoach> GetCoachByTeamId(int teamId)
        {
            this._requestMessage.RequestUri = new Uri($"https://api-football-v1.p.rapidapi.com/v3/coachs?id={teamId}");
            return await readCoach();

        }


        private async Task<ApiCoach> readCoach()
        {
            using (var response = await this._httpClient.SendAsync(this._requestMessage))
            {
                response.EnsureSuccessStatusCode();
                var coach = await response.Content.ReadFromJsonAsync<ApiCoach>();
                return coach;
            }
        }
    }
}
