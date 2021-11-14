using System;
using System.Windows;
using Microsoft.Win32;
using System.Net.Mail;
using System.Net;
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
            string baseDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == true)
            {
                destFilePath = sfd.FileName;
            }
            File.Copy(baseDirectoryPath + @"\ReadySample1.pdf", destFilePath + @".pdf");
        }

        private void MailOutput_Click(object sender, RoutedEventArgs e)
        {
            MailOutputWindow mailOutputWindow = new MailOutputWindow();
            mailOutputWindow.Owner = this;
            mailOutputWindow.ShowDialog();
        }
    }
}
