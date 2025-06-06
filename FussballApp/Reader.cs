using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;

namespace FussballApp
{
    public class API_Reader
    {
        public MatchRoot game;
        private static readonly string apiKey = "f1e793d865804096a476f8052af2587f";
        private static readonly string apiUrl = "https://api.football-data.org/v4/competitions";

        public static async Task GetCompetitions()
        {
            using (HttpClient client = new HttpClient())
            {
                // Auth-Header setzen
                client.DefaultRequestHeaders.Add("X-Auth-Token", apiKey);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = await client.GetAsync("https://api.football-data.org/v4/competitions");
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                    var result = JsonConvert.DeserializeObject<RootObject>(responseBody);
                    // JSON parsen
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Fehler: {e.Message}");
                }
            }
        }
        public static async Task GetGames(string Date1, string Date2)
        {
            using (HttpClient client = new HttpClient())
            {
                // Auth-Header setzen
                client.DefaultRequestHeaders.Add("X-Auth-Token", apiKey);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = await client.GetAsync("https://api.football-data.org/v4/matches?dateFrom=2025-05-21&dateTo=2025-05-30");
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                    var result = JsonConvert.DeserializeObject<MatchRoot>(responseBody);
                    // JSON parsen
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Fehler: {e.Message}");
                }
            }
        }
        private async Task LadeSpiele(DataGrid dataGrid)
        {
            gespielteSpiele = await GetGames("2025-05-21", "2025-05-30");

            if (gespielteSpiele != null)
            {
                Console.WriteLine($"Gefundene Spiele: {gespielteSpiele.Matches.Count}");
                // z. B. ins DataGrid laden:
                meinDataGrid.ItemsSource = gespielteSpiele.Matches;
            }
        }
    }



    public static async Task GetLeagues(string fileName)
        {
            try
            {
                string fullPath = Path.Combine("LeagueFolder//", fileName);
                string text = await File.ReadAllTextAsync(fullPath);
                var result = JsonConvert.DeserializeObject<CompetitionTeamsRoot>(text);
            }
            catch
            {
                Console.WriteLine($"Flascher Path");
            }
        }
    }
}
