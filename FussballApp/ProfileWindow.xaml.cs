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
using FussballApp;

namespace FussballApp
{
    /// <summary>
    /// Interaction logic for ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        public ProfileWindow()
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

        public void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right)
            {
                new MainWindow().Show();
                this.Close();
            }
            else if (e.Key == Key.Left)
            {
                new LigenWindow().Show();
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
            LigenWindow window = new LigenWindow();
            window.Show();
            this.Close();

        }

        private void ShowProfile(object sender, RoutedEventArgs e)
        {

        }

        private void ProfilEdit_Click(object sender, RoutedEventArgs e)
        {
            ProfileEdit window = new ProfileEdit();
            window.Show();
        }
    }
}
