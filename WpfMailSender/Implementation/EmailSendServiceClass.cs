using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Windows;
using PasswordDLL;
using WpfMailSender.Implementation.SQL;

namespace WpfMailSender
{
    /// <summary>
    /// Непосредственно отвечает за рассылку писем
    /// </summary>
    public class EmailSendServiceClass
    {
        #region vars
        private readonly string strLogin; 
        private readonly string strPassword; 
        private readonly string strSmtp = "smtp.yandex.ru"; 
        private readonly int iSmtpPort = 25; 
        private string strBody = "Привет. Тест!!!"; 
        private string strSubject = "Тест"; 
        #endregion


        public EmailSendServiceClass(string login, string password)
        {
            this.strLogin = login;
            this.strPassword = Cryptographer.GetCodPassword(password);
        }

        private void SendMail(string mail, string name) 
        {
            using (MailMessage mm = new MailMessage(strLogin, mail))
            {
                mm.Subject = this.strSubject;
                mm.Body = this.strBody;
                mm.IsBodyHtml = false;
                SmtpClient sc = new SmtpClient(this.strSmtp, this.iSmtpPort)
                {
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(this.strLogin, this.strPassword)
                };
                try
                {
                    sc.Send(mm);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Невозможно отправить письмо {ex.Message}");
                }
            }
        }
        public void SendMails(IQueryable<Email> emails)
        {
            foreach (var email in emails)
            {
                SendMail(email.Value, email.Name);
            }
        }

    }
}
