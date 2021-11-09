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
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using Microsoft.Win32;

namespace ResumeCreator
{
    public partial class DoneResumeWindow : Window
    {
        InformationWindow informationWindow;
        public DoneResumeWindow(InformationWindow informationWindow)
        {
            this.informationWindow = informationWindow;
            InitializeComponent();
        }

        private void DisplayOutput_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PDFOutput_Click(object sender, RoutedEventArgs e)
        {
            string filePath = null;
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == true)
            {
                filePath = sfd.FileName;
            }
            var helper = new WordHelper("Sample.docx", filePath);
            var items = new Dictionary<string, string>
            {
                { "<teg1>", informationWindow.textBoxSecondName.Text},
                { "<teg2>", informationWindow.textBoxFirstName.Text},
                { "<teg3>", informationWindow.textBoxThirdName.Text},
                { "<teg4>", informationWindow.textBoxPosition.Text},
                { "<teg5>", informationWindow.textBoxSalary.Text},
                { "<teg6>", informationWindow.textBoxMail.Text},
                { "<teg7>", informationWindow.textBoxPhone.Text},
                { "<teg8>", informationWindow.textBoxCity.Text},
                { "<teg9>", informationWindow.textBoxUniversity.Text}
                
                
            };
            helper.Process(items);
        }

        private void MailOutput_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
