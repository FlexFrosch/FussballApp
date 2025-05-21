using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace FussballApp
{
    public class API_Reader
    {
        private static readonly string apiKey = "f1e793d865804096a476f8052af2587f";
        private static readonly string apiUrl = "https://api.football-data.org/v4/competitions";

        public static async Task GetCompetitions()
        {
            using (HttpClient client = new HttpClient())
            {
                // Auth-Header setzen
                client.DefaultRequestHeaders.Add("X-Auth-Token", "f1e793d865804096a476f8052af2587f");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
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
    }
}
