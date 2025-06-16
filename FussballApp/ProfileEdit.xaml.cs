using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace FussballApp
{
    public partial class ProfileEdit : Window
    {
        public string TeamName => TeamHinzufuegen.Text.Trim();
        public string LigaName => (LigenComboBox.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "";

        public ProfileEdit()
        {
            InitializeComponent();
        }

        // kontrolliert ob der Eintrag in der API ist KI hat mir hier geholfen
        private async void Save_Click(object sender, RoutedEventArgs e) 
        {
            string userInput = TeamHinzufuegen.Text.Trim();
            if (string.IsNullOrEmpty(userInput))
            {
                MessageBox.Show("Bitte gib erst eine Mannschaft ein.");
                return;
            }

            var selected = LigenComboBox.SelectedItem as ComboBoxItem;
            if (selected == null)
            {
                MessageBox.Show("Bitte wähle zuerst eine Liga aus.");
                return;
            }
            string ligaCode = GetCompetitionCode(selected.Content.ToString());
            if (string.IsNullOrEmpty(ligaCode))
            {
                MessageBox.Show("Gib die passende Liga zu deiner Manschaft ein:");
                return;
            }

            // JSON-Datei laden
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "LeagueFolder", $"{ligaCode}.json");
            if (!File.Exists(filePath))
            {
                MessageBox.Show($"Daten für {selected.Content} fehlen.");
                return;
            }

            CompetitionTeamsRoot root;
            try
            {
                string json = await File.ReadAllTextAsync(filePath);
                root = JsonConvert.DeserializeObject<CompetitionTeamsRoot>(json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Einlesen der Daten:\n{ex.Message}");
                return;
            }
            // entfernt FC usw. 
            string normalizedInput = NormalizeName(userInput);

            bool exists = root.Teams
                              .Any(t => NormalizeName(t.Name) == normalizedInput);

            if (!exists)
            {
                MessageBox.Show("Deine Mannschaft existiert nicht.", "Fehler",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DialogResult = true;
            Close();
        }

        // Entfernt Suffixe wie "FC", "AFC", "Club von KI "
        private string NormalizeName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "";
            string n = name.Trim().ToLowerInvariant();
            n = Regex.Replace(n, @"\s+(fc|afc|cf|club)$", "", RegexOptions.IgnoreCase);
            return n;
        }

        private string GetCompetitionCode(string liga)
        {
            switch (liga)
            {
                case "Bundesliga (Deutschland)": return "BL1";
                case "Premier League (England)": return "PL";
                case "La Liga (Spanien)": return "PD";
                case "Serie A (Italien)": return "SA";
                case "Ligue 1 (Frankreich)": return "FL1";
                case "Primeira Liga (Portugal)": return "PPL";
                case "Champions League": return "CL";
                case "Championship (England 2. Liga)": return "ELC";
                case "Serie A (Brasilien)": return "BSA";
                case "Eredivisie (Niederlande)": return "DED";
                case "Euro 2024": return "EC";
                default: return "";
            }
        }


        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

       

    }
}
