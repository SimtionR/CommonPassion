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
    public class TeamService : ITeamService
    {
        private readonly HttpClient _httpClient;
        private readonly HttpRequestMessage _requestMessage;


        public TeamService(HttpClient httpClient)
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
        public async Task<ApiTeam> GetTeamInfo(int teamId)
        {
            ReqMessageTeamInfoId(teamId);
            return await ReturnTeam(_requestMessage);
        }

       

        public async  Task<ApiTeam> GetTeamSeasons(int teamId)
        {
            ReqMessageTeamSeasons(teamId);
            return await ReturnTeam(_requestMessage);
        }

        public async Task<ApiTeam> GetTeamStats(int leagueId, int season, int teamId)
        {
            ReqMessageTeamStats(leagueId, season, teamId);
            return await ReturnTeam(_requestMessage);
        }

        private async Task<ApiTeam> ReturnTeam(HttpRequestMessage _requestMessage)
        {
            using (var response = await _httpClient.SendAsync(_requestMessage))

            {
                response.EnsureSuccessStatusCode();
                var team = await response.Content.ReadFromJsonAsync<ApiTeam>();
                return team;
            }
        }

        private void ReqMessageTeamInfoId(int id)
        {
            this._requestMessage.RequestUri = new Uri($"https://api-football-v1.p.rapidapi.com/v3/teams?id={id}");
        }
        private void ReqMessageTeamStats(int league,int season,int id)
        {
           this. _requestMessage.RequestUri =
                new Uri($"https://api-football-v1.p.rapidapi.com/v3/teams/statistics?league={league}&season={season}&team={id}");
        }
        private void ReqMessageTeamSeasons(int id)
        {
            this._requestMessage.RequestUri = new Uri($"https://api-football-v1.p.rapidapi.com/v3/teams/seasons?team={id}");
        }
    }
}
