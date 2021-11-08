﻿using System;
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

namespace ResumeCreator
{
    /// <summary>
    /// Логика взаимодействия для InformationWindow.xaml
    /// </summary>
    public partial class InformationWindow : Window
    {
        public InformationWindow()
        {
            InitializeComponent();
        }

		private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var doneResumeWindow = new DoneResumeWindow(this);
            doneResumeWindow.Show();
        }
    }
}
