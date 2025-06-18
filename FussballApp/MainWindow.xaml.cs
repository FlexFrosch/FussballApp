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
        }

        int datum = 2;

      

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
                new LigenWindow().Show();
                this.Close();
            }
            else if (e.Key == Key.Left)
            {
                new ProfileWindow().Show();
                this.Close();
            }
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
            API_Reader.GetGames(datum, MatchesGrid);
        }

       

        private void ReloadButton_Click(object sender, RoutedEventArgs e)
        {
            API_Reader.GetGames(datum, MatchesGrid);
        }

        private void BtnGestern_Click(object sender, RoutedEventArgs e)
        {
            datum = 3;
            API_Reader.GetGames(datum, MatchesGrid);
        }

        private void BtnHeute_Click(object sender, RoutedEventArgs e)
        {
            datum = 2;
            API_Reader.GetGames(datum, MatchesGrid);
        }

        private void BtnMorgen_Click(object sender, RoutedEventArgs e)
        {
            datum = 1;
            API_Reader.GetGames(datum, MatchesGrid);
        }
    }


}