using CommonPassion_Backend.Data.ApiModels;
using CommonPassion_Backend.Data.IServicies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.Servicies
{
    public class PlayerService : IPlayerService
    {
        private readonly HttpClient _httpClient;
        private readonly HttpRequestMessage _requestMessage;

        public PlayerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _requestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                Headers =
                {
                    { "x-rapidapi-host", "api-football-v1.p.rapidapi.com" },
                    { "x-rapidapi-key", "***REMOVED***" },
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

        public async Task<ApiPlayerGame> GetPlayersGameStats(int fixture)
        {
            this._requestMessage.RequestUri =
                new Uri($"https://api-football-v1.p.rapidapi.com/v3/fixtures/players?fixture={fixture}");


            return await returnPlayer<ApiPlayerGame>();

        }

        public async Task<ApiPlayerLeague> GetPlayersStatsByLeague(int leagueId, int season)
        {
            this._requestMessage.RequestUri =
                new Uri($"https://api-football-v1.p.rapidapi.com/v3/players?league={leagueId}&season={season}");


            return await returnPlayer<ApiPlayerLeague>();
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
