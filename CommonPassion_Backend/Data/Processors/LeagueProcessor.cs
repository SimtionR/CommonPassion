using CommonPassion_Backend.Data.Entities;
using CommonPassion_Backend.Infrastrcture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.Processors
{
    public class LeagueProcessor
    {

        public static async Task<string> LoadTeam(int Id)
        {
            
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://api-football-v1.p.rapidapi.com/v3/leagues?id={Id}"),
                Headers =
                        {
                            { "x-rapidapi-host", "api-football-v1.p.rapidapi.com" },
                            { "x-rapidapi-key", "***REMOVED***" },
                        },

            };



            using (HttpResponseMessage response = await ApiHelper.ApiClient.SendAsync(request))
            {
                var stringTest = "";
                if(response.IsSuccessStatusCode)
                {
                    stringTest = await response.Content.ReadAsStringAsync();
                }


                return stringTest;
                

            }
        }
    }
}
