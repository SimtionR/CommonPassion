using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Infrastrcture
{
    public static class FunctionHelper
    {
        public static int checkingSeason(int season)
        {
            if (season >= Constants.MIN_AVAIABLE_SEASON && season <= Constants.CURRENT_SEASON)
            {

            }
            else
            {
                season = Constants.CURRENT_SEASON;

            }

            return season;
        }

        public static async Task<T> returnResponse<T>(HttpRequestMessage _requestMessage, HttpClient httpClient)
        {
            using (var response = await httpClient.SendAsync(_requestMessage))

            {
                response.EnsureSuccessStatusCode();
                var var = await response.Content.ReadFromJsonAsync<T>();
                return var;
            }
        }
/*
        public static  ActionResult<T> playerChecked<T>(T player)
        {
            if (player != null)
                return player;
            else return new { Result = NotFoundResult };
        }*/
    }
}
