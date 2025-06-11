using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;
using FussballApp;


namespace FussballApp
{
    /// <summary>
    /// Interaction logic for ProfileEdit.xaml
    /// </summary>
    public partial class ProfileEdit : Window
    {

        private string datei = "Profil.txt";

        public ProfileEdit()
        {
            InitializeComponent();
            LoadProfile();
          
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void Save_Click(object sender, RoutedEventArgs e)
        {
            var profile = new Profile
            {
                Team = TeamHinzufuegen.Text,
                Liga = (LigenComboBox.SelectedItem as ComboBoxItem)?.Content.ToString() ?? ""
            };


            File.WriteAllText(datei, profile.Serialize());

            this.Close();

        }

        private void LoadProfile()
        {
            if (!File.Exists(datei))
                return;

            try
            {
                string serialized = File.ReadAllText(datei);
                var profile = Profile.Deserialize(serialized);

                TeamHinzufuegen.Text = profile.Team;
                foreach (ComboBoxItem item in LigenComboBox.Items)
                {
                    if (item.Content.ToString() == profile.Liga)
                    {
                        LigenComboBox.SelectedItem = item;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Fehler beim Laden des Profils:\n{ex.Message}",
                    "Ladefehler",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void Upload_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
