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
                { "<teg1>", informationWindow.textBoxSecondName.Text}, //фамилия
                { "<teg2>", informationWindow.textBoxFirstName.Text}, //имя
                { "<teg3>", informationWindow.textBoxThirdName.Text}, //отчество
               // { "<teg4>", informationWindow.}, //дата рождения
                { "<teg5>", informationWindow.Pol.Text}, //пол
                { "<teg6>", informationWindow.textBoxCity.Text}, //город
                { "<teg7>", informationWindow.textBoxPosition.Text}, //должность
                { "<teg8>", informationWindow.textBoxSalary.Text}, //зарплата
                { "<teg9>", informationWindow.Occupation.Text}, //занятость
                { "<teg10>", new string ((bool) informationWindow.ReadyToMove.IsChecked ? "Да" : "Нет") }, //переезд
                { "<teg11>", new string ((bool) informationWindow.ReadyToWorkOut.IsChecked ? "Да" : "Нет")}, //командировки
                { "<teg12>", informationWindow.Marry.Text}, //семейное положение
                { "<teg13>", new string ((bool) informationWindow.Children.IsChecked ? "Да" : "Нет")}, //дети
                { "<teg14>", informationWindow.textBoxUniversity.Text}, //университет
                { "<teg15>", informationWindow.textBoxYearOfEnding.Text}, //год окончания
                { "<teg16>", informationWindow.textBoxFaculty.Text}, //факультет
                { "<tag17>",informationWindow.textBoxSpeciality.Text },
                { "<teg18", informationWindow.FormOfEducation.Text}, //форма обучения
                { "<teg19>", informationWindow.textBoxOrganiztion.Text}, //организация
                { "<teg20>", informationWindow.textBoxLastPosition.Text}, //должность
                { "<teg21>", informationWindow.textBoxMail.Text}, //электронная почта
                { "<teg22>", informationWindow.textBoxPhone.Text}, //телефон


            };
            helper.Process(items);
        }

        private void MailOutput_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
