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
            LoadLigaTeam();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string team = TeamHinzufuegen.Text;
            string liga = (LigenComboBox.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "";

            File.WriteAllLines(datei, new string[] { team, liga });

            this.Close();

        }

        private void LoadLigaTeam()
        {
            if (File.Exists(datei))
            {
                string[] zeilen = File.ReadAllLines(datei);

                if (zeilen.Length > 0)
                    TeamHinzufuegen.Text = zeilen[0];

                if (zeilen.Length > 1)
                {
                    foreach (ComboBoxItem item in LigenComboBox.Items)
                    {
                        if (item.Content.ToString() == zeilen[1])
                        {
                            LigenComboBox.SelectedItem = item;
                            break;
                        }
                    }
                }
            }
        }
    }
}
