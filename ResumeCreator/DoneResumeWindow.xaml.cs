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
            var helper = new WordHelper("Sample.docx");
            var items = new Dictionary<string, string>
            {
                { "teg1", "SUDA TEXTBOX1"},
                { "teg2", "SUDA TEXTBOX2"},
                { "teg3", "SUDA TEXTBOX3"},
                { "teg4", "SUDA TEXTBOX4"}
            };
            helper.Process(items);
        }

        private void MailOutput_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
