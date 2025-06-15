using System.Windows;
using System.Windows.Controls;

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

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
