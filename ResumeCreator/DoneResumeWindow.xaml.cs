using System.Windows;
using Microsoft.Win32;
using System.IO;

namespace ResumeCreator
{
    public partial class DoneResumeWindow : Window
    {
        public DoneResumeWindow()
        {
            InitializeComponent();
        }

        private void DisplayOutput_Click(object sender, RoutedEventArgs e)
        {
            DisplayOutputWindow displayOutputWindow = new DisplayOutputWindow();
            displayOutputWindow.Owner = this;
            displayOutputWindow.ShowDialog();
        }
    
        private void PDFOutput_Click(object sender, RoutedEventArgs e)
        {
            string destFilePath = null;
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == true)
            {
                destFilePath = sfd.FileName;
            }
            if (!string.IsNullOrEmpty(destFilePath))
                File.Copy("ReadySample.pdf", destFilePath + @".pdf");
        }

        private void MailOutput_Click(object sender, RoutedEventArgs e)
        {
            MailOutputWindow mailOutputWindow = new MailOutputWindow();
            mailOutputWindow.Owner = this;
            mailOutputWindow.ShowDialog();
        }

        private void SaveFileForFurtherModification_Click(object sender, RoutedEventArgs e)
        {
            string destFilePath = null;
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == true)
            {
                destFilePath = sfd.FileName;
            }
            if (!string.IsNullOrEmpty(destFilePath))
                File.Copy("EditableResume.resumecreator", destFilePath + @".resumecreator");
        }

        private void DoneResumeWindow_Closed(object sender, System.EventArgs e)
        {
            File.Delete("ReadySample.pdf");
            File.Delete("EditableResume.resumecreator");
        }
    }
}
