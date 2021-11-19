using System;
using System.Net;
using System.Net.Mail;
using System.Windows;

namespace ResumeCreator
{
    public partial class MailOutputWindow : Window
    {
        public MailOutputWindow()
        {
            InitializeComponent();
        }

        private void SendMessage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string baseDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
                MailAddress from = new MailAddress("resume.creator723@gmail.com", "ResumeCreator");
                MailAddress to = new MailAddress($"{textBoxMailTo.Text}");
                MailMessage m = new MailMessage(from, to);
                m.Subject = "ResumeCreator";
                m.Body = "<h2>Your resume is attached</h2>";
                m.IsBodyHtml = true;
                m.Attachments.Add(new Attachment(baseDirectoryPath + @"\ReadySample.pdf"));
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("resume.creator723@gmail.com", "ContestOneLove");
                smtp.EnableSsl = true;
                smtp.Send(m);
                MessageBox.Show("Сообщение отправлено", "ResumeCreator", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ResumeCreator", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
