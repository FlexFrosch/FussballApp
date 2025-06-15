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
using System.Windows.Controls;
using System.Windows;
using System.Windows.Data;

namespace FussballApp
{
    public class API_Reader
    {
        public MatchRoot game;
        private static readonly string apiKey = "f1e793d865804096a476f8052af2587f";
        private static readonly string apiUrl = "https://api.football-data.org/v4/competitions";

        // Chat GPT Anfang
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
        // Chat GPT Ende
        public static async Task GetGames(string Date1, string Date2, DataGrid dataGrid)
        {
            using (HttpClient client = new HttpClient())
            {
                // Auth-Header setzen
                client.DefaultRequestHeaders.Add("X-Auth-Token", apiKey);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = await client.GetAsync("https://api.football-data.org/v4/matches?dateFrom=2025-05-23&dateTo=2025-05-27");
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                    var result = JsonConvert.DeserializeObject<MatchRoot>(responseBody);

                    if (result != null)
                    {
                        foreach (Match match in result.Matches) 
                        {
                            match.Score.ScoreString = $"{match.Score.FullTime.Home.ToString()}:{match.Score.FullTime.Away.ToString()}";
                            if (match.Status == "TIMED")
                            { match.Status = $"FIN"; }
                            else if(match.Status == "SCHEDULED")
                            { match.Status = $"NP"; }
                            else
                            { match.Status = "ONG"; }
                        }
                        dataGrid.ItemsSource = result.Matches;
                    }
                    // JSON parsen
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Fehler: {e.Message}");
                }
            }
        }
        //private async Task LadeSpiele(DataGrid dataGrid)
        //{
        //    gespielteSpiele = await GetGames("2025-05-21", "2025-05-30");

        //    if (gespielteSpiele != null)
        //    {
        //        Console.WriteLine($"Gefundene Spiele: {gespielteSpiele.Matches.Count}");
        //        // z. B. ins DataGrid laden:
        //        meinDataGrid.ItemsSource = gespielteSpiele.Matches;
        //    }
        //}
        public static async Task GetLeagues(string fileName)
        {
            try
            {
                string fullPath = Path.Combine(Directory.GetCurrentDirectory(), "LeagueFolder", fileName);
                string text = await File.ReadAllTextAsync(fullPath);
                var result = JsonConvert.DeserializeObject<CompetitionTeamsRoot>(text);
            }
            catch
            {
                Console.WriteLine($"Falscher Path");
            }
        }
        public static async Task GetTable(string Competetion, DataGrid dataGrid)
        {
            using (HttpClient client = new HttpClient())
            {
                // Auth-Header setzen
                client.DefaultRequestHeaders.Add("X-Auth-Token", apiKey);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    string fullPath = $"https://api.football-data.org/v4/competitions/{Competetion}/standings";
                    HttpResponseMessage response = await client.GetAsync(fullPath);
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                    var result = JsonConvert.DeserializeObject<StandingsRoot>(responseBody);
                    if (result != null)
                    {
                        dataGrid.ItemsSource = result.Standings[0].Table;
                    }
                    // JSON parsen
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Fehler: {e.Message}");
                }
            }
        }public static async Task GetTopScorers(string Competetion, DataGrid dataGrid)
        {
            using (HttpClient client = new HttpClient())
            {
                // Auth-Header setzen
                client.DefaultRequestHeaders.Add("X-Auth-Token", apiKey);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    string fullPath = $"https://api.football-data.org/v4/competitions/{Competetion}/scorers";
                    HttpResponseMessage response = await client.GetAsync(fullPath);
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                    var result = JsonConvert.DeserializeObject<TopScorersRoot>(responseBody);
                    if (result != null)
                    {
                        dataGrid.ItemsSource = result.Scorers;
                    }
                    // JSON parsen
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Fehler: {e.Message}");
                }
            }
        }
    }
}
