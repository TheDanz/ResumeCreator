using System.Windows;

namespace ResumeCreator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateNewResume_Click(object sender, RoutedEventArgs e)
        {
            var informationWindow = new InformationWindow();
            informationWindow.Show();
            Close();
        }

        private void UploadAndChangeResume_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
