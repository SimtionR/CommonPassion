using CommonPassion_Backend.Data.ApiModels;
using CommonPassion_Backend.Data.IServicies;
using CommonPassion_Backend.Settings;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.Servicies
{
    public class PlayerService : IPlayerService
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<ApiConfigSettings> _apiSettings;
        private readonly HttpRequestMessage _requestMessage;

        public PlayerService(HttpClient httpClient, IOptions<ApiConfigSettings> apiSettings)
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
        public async Task<ApiPlayer> GetAllStatsAvaialbe()
        {
            this._requestMessage.RequestUri =
                new Uri("https://api-football-v1.p.rapidapi.com/v3/players/seasons");
            return await returnPlayer<ApiPlayer>();
        }

       

        public async Task<ApiPlayer> GetPlayerAllStats(int playerId)
        {
            this._requestMessage.RequestUri =
                new Uri($"https://api-football-v1.p.rapidapi.com/v3/players/seasons?player={playerId}");


            return await returnPlayer<ApiPlayer>();
        }

        public async Task<ApiPlayer> GetPlayerByName(string playerName,  int teamId,  int leagueId, int season)
        {
            bool  verificat=false;
            if (season > 999 && season < 10000)
                 verificat = true;


            if(teamId !=0)
            {
                if(verificat)
                {
                    this._requestMessage.RequestUri = new Uri($"https://api-football-v1.p.rapidapi.com/v3/players?team={teamId}&season={season}&search={playerName}");
                }
                else
                    this._requestMessage.RequestUri=  new Uri($"https://api-football-v1.p.rapidapi.com/v3/players?team={teamId}&search={playerName}");

            }
            else if(verificat)
            {
                this._requestMessage.RequestUri = new Uri($"https://api-football-v1.p.rapidapi.com/v3/players?league={leagueId}&season={season}&search={playerName}");
            }
            else this._requestMessage.RequestUri = new Uri($"https://api-football-v1.p.rapidapi.com/v3/players?league={leagueId}&search={playerName}");

            return await returnPlayer<ApiPlayer>();

        }

        public async Task<ApiPlayer> GetPlayersGameStats(int fixture)
        {
            this._requestMessage.RequestUri =
                new Uri($"https://api-football-v1.p.rapidapi.com/v3/fixtures/players?fixture={fixture}");


            return await returnPlayer<ApiPlayer>();

        }

        public async Task<ApiPlayer> GetPlayersStatsByLeague(int leagueId, int season)
        {
            this._requestMessage.RequestUri =
                new Uri($"https://api-football-v1.p.rapidapi.com/v3/players?league={leagueId}&season={season}");


            return await returnPlayer<ApiPlayer>();
        }

        public async Task<ApiPlayer> GetPlayersStatsByTeam(int teamId, int season)
        {
            this._requestMessage.RequestUri =
                new Uri($"https://api-football-v1.p.rapidapi.com/v3/players?team={teamId}&season={season}");


            return await returnPlayer<ApiPlayer>();
        }






        public async Task<ApiPlayer> GetPlayerStats(int playerId, int season)
        {
            this._requestMessage.RequestUri =
                new Uri($"https://api-football-v1.p.rapidapi.com/v3/players?id={playerId}&season={season}");


            return await returnPlayer<ApiPlayer>();
        }




        private async Task<T> returnPlayer<T>()
        {
            using (var response = await _httpClient.SendAsync(_requestMessage))
            {
                response.EnsureSuccessStatusCode();
                var player = await response.Content.ReadFromJsonAsync<T>();
                return player;
            }
        }
    }
}
