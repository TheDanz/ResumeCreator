using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace ResumeCreator
{
    public partial class InformationWindow : Window
    {
        Dictionary<string, string> items;
        bool isButtonAddPushed = false;
        public InformationWindow()
        {
            InitializeComponent();
        }

        public void FillInItems()
        {
            items = new Dictionary<string, string>
            {
                { "<teg1>", textBoxSecondName.Text}, //фамилия
                { "<teg2>", textBoxFirstName.Text}, //имя
                { "<teg3>", textBoxThirdName.Text}, //отчество
                { "<teg4>", datePickerDateOfBirth.Text }, //дата рождения
                { "<teg5>", comboBoxGender.Text}, //пол
                { "<teg6>", textBoxCity.Text}, //город
                { "<teg7>", textBoxPosition.Text}, //должность
                { "<teg8>", textBoxSalary.Text}, //зарплата
                { "<teg9>", Occupation.Text}, //занятость
                { "<teg10>", new string ((bool)checkBoxReadyToMove.IsChecked ? "Да" : "Нет") }, //переезд
                { "<teg11>", new string ((bool)checkBoxReadyToWorkOut.IsChecked ? "Да" : "Нет")}, //командировки
                { "<teg12>", comboBoxMarry.Text}, //семейное положение
                { "<teg13>", new string ((bool)checkBoxChildren.IsChecked ? "Да" : "Нет")}, //дети
                { "<teg14>", textBoxUniversity.Text}, //университет
                { "<teg15>", textBoxУearOfGraduation.Text}, //год окончания
                { "<teg16>", textBoxFaculty.Text}, //факультет
                { "<tag17>", textBoxSpeciality.Text },
                { "<teg18>", comboBoxFormOfEducation.Text}, //форма обучения
                { "<teg19>", textBoxOrganiztion1.Text}, //организация
                { "<teg20>", textBoxLastPosition1.Text}, //должность
                { "<teg21>", textBoxMail.Text}, //электронная почта
                { "<teg22>", textBoxPhone.Text}, //телефон
                { "<teg23>", datePickerStartWork1.Text}, //начало периода работы
                { "<teg24>", datePickerEndWork1.Text}, //окончание периода работы
                //{ "<teg25>", Achievements.}, //достижения

            };
        }

        private void Ready_Click(object sender, RoutedEventArgs e)
        {
            FillInItems();

            string baseDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;

            var wordHelper = new WordHelper("Sample1.docx");
            wordHelper.Process(items);

            var pdfHelper = new PDFHelper();
            pdfHelper.ConvertToPDF();

            File.Delete(baseDirectoryPath + @"\ReadySample1.docx");

            var doneResumeWindow = new DoneResumeWindow();
            doneResumeWindow.Show();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (isButtonAddPushed == false)
            {
                labelOrganization2.Visibility = Visibility.Visible;
                labelPosition2.Visibility = Visibility.Visible;
                labelWorkPerion2.Visibility = Visibility.Visible;
                datePickerEndWork2.Visibility = Visibility.Visible;
                datePickerStartWork2.Visibility = Visibility.Visible;
                textBoxOrganiztion2.Visibility = Visibility.Visible;
                textBoxLastPosition2.Visibility = Visibility.Visible;
                isButtonAddPushed = true;
            } 
            else
            {
                labelOrganization3.Visibility = Visibility.Visible;
                labelPosition3.Visibility = Visibility.Visible;
                labelWorkPerion3.Visibility = Visibility.Visible;
                datePickerEndWork3.Visibility = Visibility.Visible;
                datePickerStartWork3.Visibility = Visibility.Visible;
                textBoxOrganiztion3.Visibility = Visibility.Visible;
                textBoxLastPosition3.Visibility = Visibility.Visible;
            }
        }
    }
}
