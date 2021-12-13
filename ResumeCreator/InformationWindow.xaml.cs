using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace ResumeCreator
{
    public partial class InformationWindow : Window
    {
        private Dictionary<string, string> tegs;
        public bool isButtonAddPushedOnce = false;
        public bool isButtonAddPushedTwice = false;

        public InformationWindow()
        {
            InitializeComponent();
        }

        private void Ready_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               

               
                if (string.IsNullOrWhiteSpace(textBoxSecondName.Text) ||
                string.IsNullOrWhiteSpace(textBoxFirstName.Text) ||
                string.IsNullOrWhiteSpace(textBoxCity.Text) ||
                string.IsNullOrWhiteSpace(textBoxPosition.Text) ||
                string.IsNullOrWhiteSpace(textBoxSalary.Text) ||
                string.IsNullOrWhiteSpace(textBoxUniversity.Text) ||
                string.IsNullOrWhiteSpace(textBoxУearOfGraduation.Text) ||
                string.IsNullOrWhiteSpace(textBoxFaculty.Text) ||
                string.IsNullOrWhiteSpace(textBoxSpeciality.Text) ||
                string.IsNullOrWhiteSpace(textBoxMail.Text) ||
                string.IsNullOrWhiteSpace(textBoxPhone.Text) ||
                string.IsNullOrWhiteSpace(textBoxOrganiztion1.Text) ||
                string.IsNullOrWhiteSpace(textBoxLastPosition1.Text) ||
                string.IsNullOrWhiteSpace(datePickerDateOfBirth.Text) ||
                string.IsNullOrWhiteSpace(datePickerStartWork1.Text) ||
                string.IsNullOrWhiteSpace(datePickerEndWork1.Text) ||
                string.IsNullOrWhiteSpace(comboBoxGender.Text) ||
                string.IsNullOrWhiteSpace(comboBoxOccupation.Text) ||
                string.IsNullOrWhiteSpace(comboBoxMarry.Text) ||
                string.IsNullOrWhiteSpace(comboBoxFormOfEducation.Text)
                )
                {
                    throw new ArgumentException();
                }

                var addr = new System.Net.Mail.MailAddress(textBoxMail.Text);
                if (!(addr.Address == textBoxMail.Text))
                {
                    throw new Exception();
                }
                var date1 = new DateTime(year: 2007, month: 1, day: 1);
                var date2 = new DateTime(year: 1921, month: 1, day: 1);
                if ((datePickerDateOfBirth.SelectedDate > date1) || (datePickerDateOfBirth.SelectedDate < date2))
                {
                    throw new Exception("Неккоректный возраст");
                }

                if (isButtonAddPushedOnce && (string.IsNullOrWhiteSpace(textBoxOrganiztion2.Text) ||
                    string.IsNullOrWhiteSpace(textBoxLastPosition2.Text) ||
                    string.IsNullOrWhiteSpace(datePickerEndWork2.Text) ||
                    string.IsNullOrWhiteSpace(datePickerStartWork2.Text)
                    ))
                {
                    throw new ArgumentException();
                }
                if (isButtonAddPushedTwice && (string.IsNullOrWhiteSpace(textBoxOrganiztion3.Text) ||
                   string.IsNullOrWhiteSpace(textBoxLastPosition3.Text) ||
                   string.IsNullOrWhiteSpace(datePickerEndWork3.Text) ||
                   string.IsNullOrWhiteSpace(datePickerStartWork3.Text)
                   ))
                {
                    throw new ArgumentException();
                }

                string richTextBoxInfo = new TextRange(richTextBoxAchievements.Document.ContentStart, richTextBoxAchievements.Document.ContentEnd).Text;
                bool isRichTextBoxInfoEmpry = string.IsNullOrWhiteSpace(richTextBoxInfo);

                if (comboBoxGender.Text == "Мужской")
                {
                    if (comboBoxMarry.Text == "Не замужем/Не женат")
                    {
                        comboBoxMarry.Text = "Не женат";
                    }
                    else
                    {
                        comboBoxMarry.Text = "Женат";
                    }
                }
                else
                {
                    if (comboBoxMarry.Text == "Не замужем/Не женат")
                    {
                        comboBoxMarry.Text = "Не замужем";
                    }
                    else
                    {
                        comboBoxMarry.Text = "Замужем";
                    }
                }
                tegs = new Dictionary<string, string> { 
                    { "<teg1>", textBoxSecondName.Text}, // фамилия
                    { "<teg2>", textBoxFirstName.Text}, // имя
                    { "<teg3>", textBoxThirdName.Text}, // отчество
                    { "<teg4>", datePickerDateOfBirth.Text}, // дата рождения
                    { "<teg5>", comboBoxGender.Text}, // пол
                    { "<teg6>", textBoxCity.Text}, // город
                    { "<teg7>", textBoxPosition.Text}, // должность
                    { "<teg8>", textBoxSalary.Text}, // зарплата
                    { "<teg9>", comboBoxOccupation.Text}, // занятость
                    { "<teg10>", new string ((bool)checkBoxReadyToMove.IsChecked ? "Да" : "Нет") }, // переезд
                    { "<teg11>", new string ((bool)checkBoxReadyToWorkOut.IsChecked ? "Да" : "Нет")}, // командировки
                    { "<teg12>", comboBoxMarry.Text}, // семейное положение
                    { "<teg13>", new string ((bool)checkBoxChildren.IsChecked ? "Да" : "Нет")}, // дети
                    { "<teg14>", textBoxUniversity.Text}, // университет
                    { "<teg15>", textBoxУearOfGraduation.Text}, // год окончания
                    { "<teg16>", textBoxFaculty.Text}, // факультет
                    { "<teg17>", textBoxSpeciality.Text }, // специальность
                    { "<teg18>", comboBoxFormOfEducation.Text}, // форма обучения
                    { "<teg19>", textBoxOrganiztion1.Text}, // организация 1
                    { "<teg20>", textBoxLastPosition1.Text}, // должность 1
                    { "<teg21>", textBoxMail.Text}, // электронная почта
                    { "<teg22>", textBoxPhone.Text}, // телефон
                    { "<teg23>", datePickerStartWork1.Text}, // начало периода работы 1
                    { "<teg24>", datePickerEndWork1.Text}, // окончание периода работы 1
                    { "<teg25>", textBoxOrganiztion2.Text}, // организация 2
                    { "<teg26>", textBoxLastPosition2.Text}, // должность 2
                    { "<teg27>", datePickerStartWork2.Text}, // начало периода работы 2
                    { "<teg28>", datePickerEndWork2.Text}, // окончание периода работы 2
                    { "<teg29>", textBoxOrganiztion3.Text}, // организация 3
                    { "<teg30>", textBoxLastPosition3.Text}, // должность 3
                    { "<teg31>", datePickerStartWork3.Text}, // начало периода работы 3
                    { "<teg32>", datePickerEndWork3.Text}, // окончание периода работы 3
                    { "<teg33>", richTextBoxInfo}, // достижения
                    { "<teg34>", isRichTextBoxInfoEmpry ? null : "Достижения:"},
                    { "<teg35>", isButtonAddPushedOnce ? "В организации \"" : null},
                    { "<teg36>", isButtonAddPushedOnce ? "\" на должности \"" : null},
                    { "<teg37>", isButtonAddPushedOnce ? "\" c " : null},
                    { "<teg38>", isButtonAddPushedOnce ? " по " : null},
                    { "<teg40>", isButtonAddPushedTwice ? "В организации \"" : null},
                    { "<teg41>", isButtonAddPushedTwice ? "\" на должности \"" : null},
                    { "<teg42>", isButtonAddPushedTwice ? "\" c " : null},
                    { "<teg43>", isButtonAddPushedTwice ? " по " : null}
                };
                
                WordHelper wordHelper = new WordHelper("Sample.docx");
                wordHelper.Process(tegs);
                PDFHelper pdfHelper = new PDFHelper();
                pdfHelper.ConvertToPDF();
                File.Delete("ReadySample.docx");
                richTextBoxInfo = Regex.Replace(richTextBoxInfo, @"\r\n?|\n", "$");
                tegs["<teg33>"] = richTextBoxInfo;
                using (StreamWriter sw = new StreamWriter("EditableResume.resumecreator"))
                {
                    int i = 0;
                    foreach (var teg in tegs)
                    {
                        if (i < 33)
                            sw.WriteLine(teg.Value);
                        i++;
                    }
                }
                DoneResumeWindow doneResumeWindow = new DoneResumeWindow();
                Close();
                doneResumeWindow.Show();
            }
          
            catch (ArgumentException)
            {
                MessageBox.Show("Заполните все пустые поля!", "ResumeCreator", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ResumeCreator", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void Add_Click(object sender, RoutedEventArgs e)
        {
            if (isButtonAddPushedOnce == false)
            {
                labelOrganization2.Visibility = Visibility.Visible;
                labelPosition2.Visibility = Visibility.Visible;
                labelWorkPerion2.Visibility = Visibility.Visible;
                datePickerEndWork2.Visibility = Visibility.Visible;
                datePickerStartWork2.Visibility = Visibility.Visible;
                textBoxOrganiztion2.Visibility = Visibility.Visible;
                textBoxLastPosition2.Visibility = Visibility.Visible;
                isButtonAddPushedOnce = true;
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
                isButtonAddPushedTwice = true;
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (isButtonAddPushedTwice)
            {
                labelOrganization3.Visibility = Visibility.Hidden;
                labelPosition3.Visibility = Visibility.Hidden;
                labelWorkPerion3.Visibility = Visibility.Hidden;
                datePickerEndWork3.Visibility = Visibility.Hidden;
                datePickerStartWork3.Visibility = Visibility.Hidden;
                textBoxOrganiztion3.Visibility = Visibility.Hidden;
                textBoxLastPosition3.Visibility = Visibility.Hidden;
                datePickerEndWork3.Text = null;
                datePickerStartWork3.Text = null;
                textBoxOrganiztion3.Text = null;
                textBoxLastPosition3.Text = null;
                isButtonAddPushedTwice = false;
            } else if (isButtonAddPushedOnce)
            {
                labelOrganization2.Visibility = Visibility.Hidden;
                labelPosition2.Visibility = Visibility.Hidden;
                labelWorkPerion2.Visibility = Visibility.Hidden;
                datePickerEndWork2.Visibility = Visibility.Hidden;
                datePickerStartWork2.Visibility = Visibility.Hidden;
                textBoxOrganiztion2.Visibility = Visibility.Hidden;
                textBoxLastPosition2.Visibility = Visibility.Hidden;
                datePickerEndWork2.Text = null;
                datePickerStartWork2.Text = null;
                textBoxOrganiztion2.Text = null;
                textBoxLastPosition2.Text = null;
                isButtonAddPushedOnce = false;
            }
        }

        private void textBoxOnlyNumbers(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text, 0);
        }
    }
}
