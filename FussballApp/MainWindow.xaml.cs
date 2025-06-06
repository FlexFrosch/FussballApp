using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FussballApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (Darkemode.IsDarkMode)
{
    DarkMode_Click(null, null); // wendet Theme an
}

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

        }

        private void ShowLeagues(object sender, RoutedEventArgs e)
        {
            LigenWindow window = new LigenWindow();
            window.Show();
            this.Close();       
        }

        private void ShowProfile(object sender, RoutedEventArgs e)
        {
            ProfileWindow window = new ProfileWindow();
            window.Show();
            this.Close();

        }

        private void MatchesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TopNav_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ProfilButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LigenButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            API_Reader.GetCompetitions();
            API_Reader.GetGames("2025-05-21", "2025-05-30");
            API_Reader.GetLeagues("BL1.json");
        }

        public static class Darkemode
        {
            public static bool IsDarkMode
            {
                get
                {
                    if (Application.Current.Properties.Contains("DarkModeEnabled"))
                        return (bool)Application.Current.Properties["DarkModeEnabled"];
                    return false; // 
                }
                set
                {
                    Application.Current.Properties["DarkModeEnabled"] = value;
                }
            }

        }




        public  void  DarkMode_Click(object sender, RoutedEventArgs e)
        {
            if (!Darkemode.IsDarkMode)
            {
                this.Background = Brushes.White;
                DarkMode.Content = "🌙 Dark Mode";
                DarkMode.Foreground = Brushes.White;
                DarkMode.Background = new SolidColorBrush(Color.FromRgb(47, 79, 79));

                var lightBg = Brushes.White;
                var blackText = Brushes.Black;

                HomeButton.Background = lightBg;
                HomeButton.Foreground = blackText;

                LeaguesButton.Background = lightBg;
                LeaguesButton.Foreground = blackText;

                ProfileButton.Background = lightBg;
                ProfileButton.Foreground = blackText;

                HomeText.Foreground = blackText;
            }
            else
            {
                this.Background = new SolidColorBrush(Color.FromRgb(30, 30, 30));
                DarkMode.Content = "☀️ Light Mode";
                DarkMode.Foreground = Brushes.White;
                DarkMode.Background = new SolidColorBrush(Color.FromRgb(47, 79, 79));

                var dark = new SolidColorBrush(Colors.DimGray);
                var light = Brushes.White;

                HomeButton.Background = dark;
                HomeButton.Foreground = light;

                LeaguesButton.Background = dark;
                LeaguesButton.Foreground = light;

                ProfileButton.Background = dark;
                ProfileButton.Foreground = light;

                HomeText.Foreground = light;
            }

            Darkemode.IsDarkMode = !Darkemode.IsDarkMode;
        }


    }


}