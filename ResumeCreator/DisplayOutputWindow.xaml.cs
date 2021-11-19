using System;
using System.Windows;

namespace ResumeCreator
{
    public partial class DisplayOutputWindow : Window
    {
        public DisplayOutputWindow()
        {
            InitializeComponent();
            string baseDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
            webBrowser.Navigate(@"file:\\\" + baseDirectoryPath + "ReadySample.pdf");
        }
    }
}
