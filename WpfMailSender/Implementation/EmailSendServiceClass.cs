using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using WpfMailSender.Test.Models;

namespace WpfMailSender
{
    /// <summary>
    /// Непосредственно отвечает за рассылку писем
    /// </summary>
    public class EmailSendServiceClass
    {

        public string SendMessadge(UsersData user, List<string> listStrMails, TextMail text)
        {
            foreach (var item in listStrMails)
            {
                using (MailMessage mailMessage = new MailMessage(user.EmailUser, item))
                {
                    mailMessage.Subject = text.Subject;
                    mailMessage.Body = text.Body;
                    mailMessage.IsBodyHtml = false;
                    using (SmtpClient sc = new SmtpClient(user.SmtpAddres, user.SmtpPort))
                    {
                        sc.EnableSsl = true;
                        sc.Credentials = new NetworkCredential(user.EmailUser, user.PasswordUser);
                        try
                        {
                            sc.Send(mailMessage);
                        }
                        catch
                        {
                            return "Произошла ошибка";
                        }
                    }
                }
            }
            return "Сообщение отправленно";
        }

    }
}
