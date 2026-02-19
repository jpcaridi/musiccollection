using System.Windows;

namespace MusicCollectionForms
{
    public partial class ChangePasswordWindow : Window
    {
        public string CurrentPassword => CurrentPasswordBox.Password;
        public string NewPassword => NewPasswordBox.Password;

        public ChangePasswordWindow()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
