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

        private void ShowHome(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();

        }

        private void ShowLeagues(object sender, RoutedEventArgs e)
        {

        }

        private void ShowProfile(object sender, RoutedEventArgs e)
        {
            ProfileWindow window = new ProfileWindow();
            window.Show();
            this.Close();

        }

        private void LeagueComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TableGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
