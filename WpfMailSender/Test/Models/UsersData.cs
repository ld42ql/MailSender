using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMailSender.Test.Models
{
    /// <summary>
    /// Информация о пользователе
    /// </summary>
    public class UsersData
    {
        private int id;
        private string email;
        private string password;
        private string smtpAddres;
        private int smtpPort;

        public int Id { get => id; set => id = value; }
        public string EmailUser { get => email; set => email = value; }
        public string PasswordUser { get => password; set => password = value; }
        public string SmtpAddres { get => smtpAddres; set => smtpAddres = value; }
        public int SmtpPort { get => smtpPort; set => smtpPort = value; }
    }
}
