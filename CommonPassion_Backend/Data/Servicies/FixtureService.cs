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
    public class FixtureService : IFixtureService
    {
        private readonly HttpClient _httpClient;
        private readonly HttpRequestMessage _requestMessage;

        public FixtureService(HttpClient httpClient)
        {
            _httpClient = httpClient;

            _requestMessage= new HttpRequestMessage
            {
                Method = HttpMethod.Get,
               
                Headers =
                {
                    { "x-rapidapi-host", "api-football-v1.p.rapidapi.com" },
                    { "x-rapidapi-key", "***REMOVED***" },
                },
            };
        }

        public async Task<ApiFixture> GetAllLiveImportantFixtures()
        {
            this._requestMessage.RequestUri = new Uri("https://api-football-v1.p.rapidapi.com/v3/fixtures?live=39-140-135-78-61-238");
            return await ReadFixture();
        }

        public async Task<ApiFixture> GetFixturesByLeagueRound(int leagueId, int round, int season)
        {
            this._requestMessage.RequestUri = new Uri($"https://api-football-v1.p.rapidapi.com/v3/fixtures?league={leagueId}&season={season}&round=Regular%20Season%20-%20{round}");
            return await ReadFixture();

        }

        public async Task<ApiFixture> GetFixturesByTeam(int teamId, int season)
        {
            this._requestMessage.RequestUri = new Uri($"https://api-football-v1.p.rapidapi.com/v3/fixtures?season={season}&team={teamId}");
            return await ReadFixture();
        }

        public async Task<ApiFixture> GetFixtureStats(string fixtureId)
        {
            this._requestMessage.RequestUri = new Uri($"https://api-football-v1.p.rapidapi.com/v3/fixtures?id={fixtureId}");
            return await ReadFixture();
        }

        public async Task<ApiFixture> GetH2HFixtures(int teamId1, int teamId2)
        {
            this._requestMessage.RequestUri = new Uri($"https://api-football-v1.p.rapidapi.com/v3/fixtures/headtohead?h2h={teamId1}-{teamId2}");
            return await ReadFixture();
        }

        public async Task<ApiFixture> GetTodayFixturesFromLeague(int leagueId, string date, int season)
        {
            this._requestMessage.RequestUri = new Uri($"https://api-football-v1.p.rapidapi.com/v3/fixtures?date={date}&league={leagueId}&season={season}");
            return await ReadFixture();
        }

        private async Task<ApiFixture> ReadFixture()
        {
            using (var response = await this._httpClient.SendAsync(this._requestMessage))
            {
                response.EnsureSuccessStatusCode();
                var fixtures = await response.Content.ReadFromJsonAsync<ApiFixture>();

                return fixtures;
            }
        }
    }
}
