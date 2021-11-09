using System;
using System.Collections.Generic;
using System.Windows;
using Microsoft.Win32;
using System.Net.Mail;
using System.Net;

namespace ResumeCreator
{
    public partial class DoneResumeWindow : Window
    {
        InformationWindow informationWindow;
        Dictionary<string, string> items;
        public DoneResumeWindow(InformationWindow informationWindow)
        {
            this.informationWindow = informationWindow;
            FillInItems();
            InitializeComponent();
        }

        public void FillInItems()
        {
            this.items = new Dictionary<string, string>
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
            helper.Process(items);
        }

        private void MailOutput_Click(object sender, RoutedEventArgs e)
        {
            var helper = new WordHelper("Sample.docx", @"C:\Users\Danil\Desktop\fpg");
            helper.Process(items);
            try
            {
                MailAddress from = new MailAddress("resume.creator723@gmail.com", "ResumeCreator");
                MailAddress to = new MailAddress(this.textBoxUserMail.Text);
                MailMessage m = new MailMessage(from, to);
                m.Subject = "ResumeCreator";
                m.Body = "<h2>Your resume is attached</h2>";
                m.IsBodyHtml = true;
                m.Attachments.Add(new Attachment(@"C:\Users\Danil\Desktop\fpg.pdf"));
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("resume.creator723@gmail.com", "ContestOneLove");
                smtp.EnableSsl = true;
                smtp.Send(m);
                MessageBox.Show("Message sent");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
