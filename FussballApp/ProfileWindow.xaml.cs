using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FussballApp
{
    public partial class ProfileWindow : Window
    {
        private const string FileName = "profiles.json";

        // bindable Collection aller Profile
        public ObservableCollection<Profile> Profiles { get; }
            = new ObservableCollection<Profile>();

        public ProfileWindow()
        {
            InitializeComponent();
            DataContext = this;
            LoadProfiles();
        }

        private void ProfilEdit_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new ProfileEdit();
            bool? saved = dlg.ShowDialog();
            if (saved == true)
            {
                Profiles.Add(new Profile
                {
                    Team = dlg.TeamName,
                    Liga = dlg.LigaName
                });
                SaveProfiles();
            }
        }

        private void RemoveTeam_Click(object sender, RoutedEventArgs e)
        {
            if (TeamsListView.SelectedItem is Profile p)
            {
                Profiles.Remove(p);
                SaveProfiles();
            }
        }

        private void RemoveLiga_Click(object sender, RoutedEventArgs e)
        {
            if (LigenListView.SelectedItem is Profile p)
            {
                Profiles.Remove(p);
                SaveProfiles();
            }
        }

        private void ShowHome(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void ShowLeagues(object sender, RoutedEventArgs e)
        {
            new LigenWindow().Show();
            Close();
        }

        private void ShowProfile(object sender, RoutedEventArgs e)
        {
        }

        public void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right)
            {
                new MainWindow().Show();
                Close();
            }
            else if (e.Key == Key.Left)
            {
                new LigenWindow().Show();
                Close();
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                WindowStyle = WindowStyle.SingleBorderWindow;
                ResizeMode = ResizeMode.CanResize;
                WindowState = WindowState.Normal;
            }
            base.OnKeyDown(e);
        }

        private void LoadProfiles()
        {
            if (!File.Exists(FileName)) return;

            try
            {
                string json = File.ReadAllText(FileName);
                var list = JsonSerializer.Deserialize<List<Profile>>(json);
                if (list != null)
                    foreach (var p in list)
                        Profiles.Add(p);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Laden:");
            }
        }

        private void SaveProfiles()
        {
            try
            {
                var list = Profiles.ToList();
                string json = JsonSerializer.Serialize(list);
                File.WriteAllText(FileName, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Speichern:");
            }
        }
    }
}
