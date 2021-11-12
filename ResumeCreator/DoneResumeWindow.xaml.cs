using System;
using System.Collections.Generic;
using System.Windows;
using Microsoft.Win32;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace ResumeCreator
{
    public partial class DoneResumeWindow : Window
    {
        public DoneResumeWindow()
        {
            InitializeComponent();
        }

        private void DisplayOutput_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PDFOutput_Click(object sender, RoutedEventArgs e)
        {
            string destFilePath = null;
            string baseDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == true)
            {
                destFilePath = sfd.FileName;
            }
            File.Copy(baseDirectoryPath + @"\ReadySample1.pdf", destFilePath + @".pdf");
            File.Delete(baseDirectoryPath + @"\ReadySample1.pdf");
        }

        private void MailOutput_Click(object sender, RoutedEventArgs e)
        {
            string baseDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
            try
            {
                MailAddress from = new MailAddress("resume.creator723@gmail.com", "ResumeCreator");
                MailAddress to = new MailAddress(this.textBoxUserMail.Text);
                MailMessage m = new MailMessage(from, to);
                m.Subject = "ResumeCreator";
                m.Body = "<h2>Your resume is attached</h2>";
                m.IsBodyHtml = true;
                m.Attachments.Add(new Attachment(baseDirectoryPath + @"\ReadySample1.pdf"));
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("resume.creator723@gmail.com", "ContestOneLove");
                smtp.EnableSsl = true;
                smtp.Send(m);
                MessageBox.Show("Message sent");
                System.Threading.Thread.Sleep(5000);
                File.Delete(baseDirectoryPath + @"\ReadySample1.pdf");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
