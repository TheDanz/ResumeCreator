using System;
using System.IO;
using System.Linq;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Collections.Generic;

namespace ResumeCreator
{
    public partial class MainWindow : Window
    {
        InformationWindow informationWindow = new InformationWindow();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateNewResume_Click(object sender, RoutedEventArgs e)
        {
            informationWindow.Show();
            Close();
        }

        private void UploadAndChangeResume_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string filePath = null;
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == true)
                {
                    filePath = ofd.FileName;
                }
                var textBoxes = new Dictionary<string, TextBox> {
                    { "<teg1>", informationWindow.textBoxSecondName},
                    { "<teg2>", informationWindow.textBoxFirstName},
                    { "<teg3>", informationWindow.textBoxThirdName},
                    { "<teg6>", informationWindow.textBoxCity},
                    { "<teg7>", informationWindow.textBoxPosition},
                    { "<teg8>", informationWindow.textBoxSalary},
                    { "<teg14>", informationWindow.textBoxUniversity},
                    { "<teg15>", informationWindow.textBoxУearOfGraduation},
                    { "<teg16>", informationWindow.textBoxFaculty},
                    { "<teg17>", informationWindow.textBoxSpeciality},
                    { "<teg19>", informationWindow.textBoxOrganiztion1},
                    { "<teg20>", informationWindow.textBoxLastPosition1},
                    { "<teg21>", informationWindow.textBoxMail},
                    { "<teg22>", informationWindow.textBoxPhone},
                    { "<teg25>", informationWindow.textBoxOrganiztion2},
                    { "<teg26>", informationWindow.textBoxLastPosition2},
                    { "<teg29>", informationWindow.textBoxOrganiztion3},
                    { "<teg30>", informationWindow.textBoxLastPosition3}
                };
                var datePickers = new Dictionary<string, DatePicker> {
                    { "<teg4>", informationWindow.datePickerDateOfBirth},
                    { "<teg23>", informationWindow.datePickerStartWork1},
                    { "<teg24>", informationWindow.datePickerEndWork1},
                    { "<teg27>", informationWindow.datePickerStartWork2},
                    { "<teg28>", informationWindow.datePickerEndWork2},
                    { "<teg31>", informationWindow.datePickerStartWork3},
                    { "<teg32>", informationWindow.datePickerEndWork3},
                };
                var comboBoxes = new Dictionary<string, ComboBox> {
                    { "<teg5>", informationWindow.comboBoxGender},
                    { "<teg9>", informationWindow.comboBoxOccupation},
                    { "<teg12>", informationWindow.comboBoxMarry},
                    { "<teg18>", informationWindow.comboBoxFormOfEducation}
                };
                var checkBoxes = new Dictionary<string, CheckBox> {
                    { "<teg10>", informationWindow.checkBoxReadyToMove},
                    { "<teg11>", informationWindow.checkBoxReadyToWorkOut},
                    { "<teg13>", informationWindow.checkBoxChildren}
                };

                using (StreamReader sr = new StreamReader(filePath))
                {
                    string str = null;
                    for (int i = 1; i <= 33; i++)
                    {
                        str = sr.ReadLine();
                        if (str == "Замужем" || str == "Женат")
                            str = "Замужем/Женат";
                        if (str == "Не замужем" || str == "Не женат")
                            str = "Не замужем/Не женат";
                        if (textBoxes.Keys.Contains("<teg" + i + ">"))
                            textBoxes["<teg" + i + ">"].Text = str;
                        else if (comboBoxes.Keys.Contains("<teg" + i + ">"))
                            comboBoxes["<teg" + i + ">"].Text = str;
                        else if (checkBoxes.Keys.Contains("<teg" + i + ">"))
                        {
                            if (str == "Да")
                                checkBoxes["<teg" + i + ">"].IsChecked = true;
                            else
                                checkBoxes["<teg" + i + ">"].IsChecked = false;
                        }
                        else if (datePickers.Keys.Contains("<teg" + i + ">"))
                            datePickers["<teg" + i + ">"].Text = str;
                        else
                        {
                            str = str.Replace("$", "\n");
                            informationWindow.richTextBoxAchievements.AppendText(str);
                        }
                    }
                }

                if (!string.IsNullOrWhiteSpace(textBoxes["<teg25>"].Text))
                {
                    informationWindow.Add_Click(sender, e);
                }

                if (!string.IsNullOrWhiteSpace(textBoxes["<teg29>"].Text))
                {
                    informationWindow.Add_Click(sender, e);
                }

                informationWindow.Show();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ResumeCreator", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
