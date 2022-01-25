using CommonPassion_Backend.Data.ApiModels;
using CommonPassion_Backend.Data.IServicies;
using CommonPassion_Backend.Infrastrcture;
using CommonPassion_Backend.Settings;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.Servicies
{
    public class PlayerStandingService : IPlayerStandingService
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<ApiConfigSettings> _apiSettings;
        private HttpRequestMessage _requestMessage;

        public PlayerStandingService(HttpClient httpClient, IOptions<ApiConfigSettings> apiSettings)
        {
            _httpClient = httpClient;
            _apiSettings = apiSettings;
            _requestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                Headers =
    {
                 { "x-rapidapi-host", apiSettings.Value.ApiHost},
                 { "x-rapidapi-key", apiSettings.Value.ApiKey },
    },
            };
        }


        public async Task<ApiPlayerStanding> GetMostRedCardsFromLeague(int leagueId, int season)
        {
            season =FunctionHelper.checkingSeason(season);
            this._requestMessage.RequestUri = new Uri($"https://api-football-v1.p.rapidapi.com/v3/players/topredcards?league={leagueId}&season={season}");
            //testing if returning from Function helper works

            var redCards =await FunctionHelper.returnResponse<ApiPlayerStanding>(this._requestMessage, this._httpClient);
            return redCards;
        }

        public async Task<ApiPlayerStanding> GetMostYellowCardsFromLeague(int leagueId, int season)
        {
            season =FunctionHelper.checkingSeason(season);
            this._requestMessage.RequestUri = new Uri($"https://api-football-v1.p.rapidapi.com/v3/players/topyellowcards?league={leagueId}&season={season}");
            //testing if returning from Function helper works

            var yellowCards = await FunctionHelper.returnResponse<ApiPlayerStanding>(this._requestMessage, this._httpClient);
            return yellowCards;
        }

        public async Task<ApiPlayerStanding> GetTopAssistsFromleague(int leagueId, int season)
        {
            season =FunctionHelper.checkingSeason(season);
            this._requestMessage.RequestUri = new Uri($"https://api-football-v1.p.rapidapi.com/v3/players/topassists?league={leagueId}&season={season}");
            //testing if returning from Function helper works

            var topAssists = await FunctionHelper.returnResponse<ApiPlayerStanding>(this._requestMessage, this._httpClient);
            return topAssists;
        }

        public async Task<ApiPlayerStanding> GetTopScorersFromLeague(int leagueId, int season)
        {
            season= FunctionHelper.checkingSeason(season);
            this._requestMessage.RequestUri = new Uri($"https://api-football-v1.p.rapidapi.com/v3/players/topscorers?league={leagueId}&season={season}");
            //testing if returning from Function helper works

            var goalScorers = await FunctionHelper.returnResponse<ApiPlayerStanding>(this._requestMessage, this._httpClient);
            return goalScorers;
        }
    }
    }

