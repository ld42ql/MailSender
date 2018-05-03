using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using WpfMailSender.Test.Models;
using System.Collections.ObjectModel;

namespace WpfMailSender
{
    /// <summary>
    /// Непосредственно отвечает за рассылку писем
    /// </summary>
    public class EmailSendServiceClass
    {
        public ObservableCollection<StatusMessadge> messadgeStatus;
        
        public void SendMessadge(UsersData user, List<string> listStrMails, TextMail text)
        {
            messadgeStatus = new ObservableCollection<StatusMessadge>();

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
                            messadgeStatus.Add(new StatusMessadge
                            {
                                Status = "Отправленно",
                                Email = item,
                                Date = DateTime.Now
                            }
                                );
                        }
                        catch
                        {
                            messadgeStatus.Add(new StatusMessadge
                            {
                                Status = "Не отправленно",
                                Email = item,
                                Date = DateTime.Now
                            }
                                  );
                            continue;
                        }
                    }
                }
            }
            
        }
    }
}
