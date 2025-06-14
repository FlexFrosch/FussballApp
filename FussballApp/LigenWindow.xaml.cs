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

namespace FussballApp
{
    /// <summary>
    /// Interaction logic for LigenWindow.xaml
    /// </summary>
    public partial class LigenWindow : Window
    {
        public LigenWindow()
        {
            InitializeComponent();
        }

        string competition = "PL";
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.WindowStyle = WindowStyle.SingleBorderWindow;
                this.ResizeMode = ResizeMode.CanResize;
                this.WindowState = WindowState.Normal;
            }

            base.OnKeyDown(e);
        }


        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right)
            {
                new ProfileWindow().Show();
                this.Close();
            }
            else if (e.Key == Key.Left)
            {
                new MainWindow().Show();
                this.Close();
            }
        }
        private void ShowHome(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();

        }

        private void ShowLeagues(object sender, RoutedEventArgs e)
        {
            API_Reader.GetTable(competition, TableGrid);
        }

        private void ShowProfile(object sender, RoutedEventArgs e)
        {
            ProfileWindow window = new ProfileWindow();
            window.Show();
            this.Close();

        }

        private void LeagueComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // ChatGPT weil wusste nicht wie ich den Tag bekomme
            if (LeagueComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                competition = selectedItem.Tag.ToString();
            }
            API_Reader.GetTable(competition, TableGrid);
        }

        private void TableGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            API_Reader.GetTable(competition, TableGrid);
        }
}
}
