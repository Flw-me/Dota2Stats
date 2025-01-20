using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading.Tasks;
using System.Security.Policy;
using System.Security.Principal;
using System.Text.Json;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using System.Windows;


namespace Dota2Stats
{
    class DotaStatsService
    {
        private readonly HttpClient httpClient;
        private const string BASE_URL = "https://api.opendota.com/api/explorer";

        // Вычисляем Unix Timestamp для текущей даты минус 1 месяц
        long oneMonthAgoTimestamp = DateTimeOffset.UtcNow.AddMonths(-1).ToUnixTimeSeconds();
        public DotaStatsService()
        {
            httpClient = new HttpClient();
        }

        //Отправляем API запрос на получение списка матчей
        public async Task<List<Match>> GetMatchesAsync(int heroId_1, int heroId_2)
        {
            using (HttpClient client = new HttpClient())
            {
                long oneMonthAgoTimestamp = DateTimeOffset.UtcNow.AddMonths(-1).ToUnixTimeSeconds();

                string apiUrl = $"https://api.opendota.com/api/explorer?sql=" +
                                $"SELECT match_id, radiant_win " +
                                $"FROM matches " +
                                $"WHERE start_time > {oneMonthAgoTimestamp} " +
                                $"AND EXISTS (SELECT 1 FROM player_matches WHERE match_id = matches.match_id AND hero_id = {heroId_1}) " +
                                $"AND EXISTS (SELECT 1 FROM player_matches WHERE match_id = matches.match_id AND hero_id = {heroId_2}) " +
                                $"LIMIT 100";

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    // Используем обёртку для десериализации
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse<Match>>(jsonResponse);
                    MessageBox.Show(apiResponse.Rows.ToString());
                    return apiResponse.Rows;
                }
                else
                {
                    throw new Exception($"Ошибка при запросе данных: {response.StatusCode}");
                }
            }
        }
    }
}
