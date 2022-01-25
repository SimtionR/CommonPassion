using CommonPassion_Backend.Data.ApiModels;
using CommonPassion_Backend.Data.IServicies;
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
    public class FixtureService : IFixtureService
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<ApiConfigSettings> _apiSettings;
        private readonly HttpRequestMessage _requestMessage;

        public FixtureService(HttpClient httpClient, IOptions<ApiConfigSettings> apiSettings)
        {
            _httpClient = httpClient;
            _apiSettings = apiSettings;
            _requestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
               
                Headers =
                {
                    { "x-rapidapi-host", apiSettings.Value.ApiHost },
                    { "x-rapidapi-key",  apiSettings.Value.ApiKey },
                },
            };
        }

        public async Task<IEnumerable<ApiFixture>> GetAllLiveImportantFixtures()
        {
            this._requestMessage.RequestUri = new Uri("https://api-football-v1.p.rapidapi.com/v3/fixtures?live=39-140-135-78-61-238");
            return await ReadFixture<IEnumerable<ApiFixture>>();
        }

        public async Task<ApiFixture> GetFixturesByLeagueRound(int leagueId, int round, int season)
        {
            this._requestMessage.RequestUri = new Uri($"https://api-football-v1.p.rapidapi.com/v3/fixtures?league={leagueId}&season={season}&round=Regular%20Season%20-%20{round}");
            return await ReadFixture<ApiFixture>();

        }

        public async Task<ApiFixture> GetFixturesByTeam(int teamId, int season)
        {
            this._requestMessage.RequestUri = new Uri($"https://api-football-v1.p.rapidapi.com/v3/fixtures?season={season}&team={teamId}");
            //return await ReadFixture<ApiFixture>();
            using (var response = await this._httpClient.SendAsync(this._requestMessage))
            {
                response.EnsureSuccessStatusCode();
                var fixtures = await response.Content.ReadFromJsonAsync<ApiFixture>();

                return fixtures;
            }
        }

        public async Task<ApiFixture> GetFixtureStats(string fixtureId)
        {
            this._requestMessage.RequestUri = new Uri($"https://api-football-v1.p.rapidapi.com/v3/fixtures?id={fixtureId}");
            return await ReadFixture<ApiFixture>();
        }

        public async Task<ApiFixture> GetH2HFixtures(int teamId1, int teamId2)
        {
            this._requestMessage.RequestUri = new Uri($"https://api-football-v1.p.rapidapi.com/v3/fixtures/headtohead?h2h={teamId1}-{teamId2}");
            return await ReadFixture<ApiFixture>();
        }

        public async Task<ApiFixture> GetNextClubFixtures(int nbFixtures, int teamId)
        {
            this._requestMessage.RequestUri = new Uri($"https://api-football-v1.p.rapidapi.com/v3/fixtures?team={teamId}&next={nbFixtures}");

            return await ReadFixture<ApiFixture>();
        }

        public async Task<ApiFixture> GetTodayFixturesFromLeague(int leagueId, string date, int season)
        {
            this._requestMessage.RequestUri = new Uri($"https://api-football-v1.p.rapidapi.com/v3/fixtures?date={date}&league={leagueId}&season={season}");
            return await ReadFixture<ApiFixture>();
        }

        private async Task<T> ReadFixture<T>()
        {
            using (var response = await this._httpClient.SendAsync(this._requestMessage))
            {
                response.EnsureSuccessStatusCode();
                var fixtures = await response.Content.ReadFromJsonAsync<T>();

                return fixtures;
            }
        }
    }
}
