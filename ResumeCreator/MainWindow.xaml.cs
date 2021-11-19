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
            var infoWindow = new InformationWindow();
            infoWindow.Show();
            Close();
        }

        private void UploadAndChangeResume_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
