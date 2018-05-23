using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProjetoRussia.UWP.Constants;
using ProjetoRussia.UWP.Models;

namespace ProjetoRussia.UWP.Services
{
    public class RussiaServiceApi : IRussiaServiceApi
    {
        private readonly string _token;
        private readonly HttpClient _httpClient;

        public RussiaServiceApi(HttpClient httpClient)
        {
            _httpClient = httpClient;            

            var login = "{\"userID\": \"ajesus\",\"accessKey\": \"ajesus\"}";
            
            var result = _httpClient.PostAsync(Api.BASE_URL + Api.LOGIN_URL, new StringContent(login, Encoding.UTF8, "application/json") ).Result;
            _token = JsonConvert.DeserializeAnonymousType(result.Content.ReadAsStringAsync().Result, new { AccessToken = "" }).AccessToken;
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _token);
        }

        public async Task<IEnumerable<TimeDto>> ListarTimes()
        {
            var content = await _httpClient.GetStringAsync(Api.BASE_URL + Api.TIMES_URL);
            //var result = await content.Content.ReadAsStringAsync();

            
            var lista = JsonConvert.DeserializeObject<IEnumerable<TimeDto>>(content);
            return lista;
        }

        public async Task<bool> CriarTime(TimeDto time)
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(time), Encoding.UTF8, "application/json");            
            var result = await _httpClient.PostAsync(Api.BASE_URL + Api.TIMES_URL, httpContent);

            return result.IsSuccessStatusCode;            
        }

        public async Task<IEnumerable<JogoDto>> ListarJogos()
        {
            var content = await _httpClient.GetAsync(Api.BASE_URL + Api.JOGOS_URL);
            var result = await content.Content.ReadAsStringAsync();

            if (content.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                //Manda o FDP pro login
            }
            var lista = JsonConvert.DeserializeObject<IEnumerable<JogoDto>>(result);
            return lista;
        }

        public async Task<bool> CriarJogo(JogoDto jogo)
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(jogo),
                Encoding.UTF8, "application/json");
            var result = await _httpClient.PostAsync(Api.BASE_URL + Api.JOGOS_URL, httpContent);

            return result.IsSuccessStatusCode;
        }
    }
}
