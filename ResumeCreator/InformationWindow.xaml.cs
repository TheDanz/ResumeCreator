using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace ResumeCreator
{
    public partial class InformationWindow : Window
    {
        Dictionary<string, string> items;
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
                { "<teg4>", DateOfBirth.Text }, //дата рождения
                { "<teg5>", Pol.Text}, //пол
                { "<teg6>", textBoxCity.Text}, //город
                { "<teg7>", textBoxPosition.Text}, //должность
                { "<teg8>", textBoxSalary.Text}, //зарплата
                { "<teg9>", Occupation.Text}, //занятость
                { "<teg10>", new string ((bool)ReadyToMove.IsChecked ? "Да" : "Нет") }, //переезд
                { "<teg11>", new string ((bool)ReadyToWorkOut.IsChecked ? "Да" : "Нет")}, //командировки
                { "<teg12>", Marry.Text}, //семейное положение
                { "<teg13>", new string ((bool)Children.IsChecked ? "Да" : "Нет")}, //дети
                { "<teg14>", textBoxUniversity.Text}, //университет
                { "<teg15>", textBoxYearOfEnding.Text}, //год окончания
                { "<teg16>", textBoxFaculty.Text}, //факультет
                { "<tag17>", textBoxSpeciality.Text },
                { "<teg18", FormOfEducation.Text}, //форма обучения
                { "<teg19>", textBoxOrganiztion.Text}, //организация
                { "<teg20>", textBoxLastPosition.Text}, //должность
                { "<teg21>", textBoxMail.Text}, //электронная почта
                { "<teg22>", textBoxPhone.Text}, //телефон
                { "<teg23>", StartWork.Text}, //начало периода работы
                { "<teg24>", EndWork.Text}, //окончание периода работы
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
    }
}
