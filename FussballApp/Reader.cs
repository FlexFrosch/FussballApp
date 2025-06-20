﻿using System;
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

        // Scores werden nicht angezeigt da API es nicht rausgibt in C#. Ich finde den Fehler nicht

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
        public static async Task GetGames(int GesternEinsHeuteZweiMorgenDrei ,DataGrid dataGrid)
        {
            string datum = DateTime.Today.ToString("yyyy-MM-dd");
            if (GesternEinsHeuteZweiMorgenDrei == 1)
            {
                datum = DateTime.Today.AddDays(1).ToString("yyyy-MM-dd");
            }
            if (GesternEinsHeuteZweiMorgenDrei == 3)
            {
                datum = DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd");
            }
            using (HttpClient client = new HttpClient())
            {
                // Auth-Header setzen
                client.DefaultRequestHeaders.Add("X-Auth-Token", apiKey);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = await client.GetAsync($"https://api.football-data.org/v4/matches?dateFrom={datum}&dateTo={datum}");
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                    var result = JsonConvert.DeserializeObject<MatchRoot>(responseBody);

                    if (result != null)
                    {
                        foreach (Match match in result.Matches) 
                        {
                            if (match.Score.FullTime.Home != null && match.Score.FullTime.Away != null)
                            { match.Score.ScoreString = $"{match.Score.FullTime.Home.ToString()}:{match.Score.FullTime.Away.ToString()}"; }
                            else
                            {
                                match.Score.ScoreString = "N/A";
                            }
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


        // Konnten wir nicht machen da es zu anstrengend war für meinen Laptop weshalb ich glaube das es zu viel Leistung braucht es zu machen
        // Deshalb nicht fertig implementiert da zu anstrengend für meine CPU.
        // Ergibt vielleicht nicht alles Sinn da ich GetGames kopiert habe und abändern wollte damit es funktioniert


        //public static async Task GetFavouriteGames(string Date1, string Date2, DataGrid dataGrid)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        // Auth-Header setzen
        //        client.DefaultRequestHeaders.Add("X-Auth-Token", apiKey);
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        try
        //        {
        //            for (int i = 0; i < 1;)
        //            {
        //                string text = File.ReadAllText("profiles.json");
        //                var list = JsonConvert.DeserializeObject<List<Profile>>(text);
        //                List<int> teams = new List<int>();
        //                if (list != null)
        //                {
        //                    string fullPath = Path.Combine(Directory.GetCurrentDirectory(), "LeagueFolder", "alle.json");
        //                    var allTeams = await File.ReadAllTextAsync(fullPath);
        //                    List<UeberpruefungsRoot> alleTeams = JsonConvert.DeserializeObject<List<UeberpruefungsRoot>>(allTeams);
        //                    int j = 0;
        //                    foreach (var p in list)
        //                    {
        //                        foreach(var t in alleTeams)
        //                        {
        //                            if(p.Team == t.Name)
        //                            {
        //                                teams.Append(t.Id);
        //                                j ++;
        //                                if (j == 100)
        //                                {
        //                                    j = 0;
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
                    //HttpResponseMessage response = await client.GetAsync("https://api.football-data.org/v4/matches?dateFrom=2025-05-23&dateTo=2025-05-27");
                    //response.EnsureSuccessStatusCode();

                    //string responseBody = await response.Content.ReadAsStringAsync();

                    //var result = JsonConvert.DeserializeObject<MatchRoot>(responseBody);

                    //if (result != null)
                    //{
                    //    foreach (Match match in result.Matches)
                    //    {
                    //        if (match.Score.FullTime.Home != null && match.Score.FullTime.Away != null)
                    //        { match.Score.ScoreString = $"{match.Score.FullTime.Home.ToString()}:{match.Score.FullTime.Away.ToString()}"; }
                    //        else
                    //        {
                    //            match.Score.ScoreString = "N/A";
                    //        }
                    //        if (match.Status == "TIMED")
                    //        { match.Status = $"FIN"; }
                    //        else if (match.Status == "SCHEDULED")
                    //        { match.Status = $"NP"; }
                    //        else
                    //        { match.Status = "ONG"; }
                    //    }
                    //    dataGrid.ItemsSource = result.Matches;
                    //}
                    //// JSON parsen
        //        }
        //        catch (HttpRequestException e)
        //        {
        //            Console.WriteLine($"Fehler: {e.Message}");
        //        }
        //    }
        //}


        // Unnötig könnte aber vielleicht noch gebraucht werden


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
