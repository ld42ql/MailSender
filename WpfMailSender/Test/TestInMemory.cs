using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMailSender.Test.Models;

namespace WpfMailSender
{
    /// <summary>
    /// Тестовый класс который симулирует работу БД
    /// </summary>
   public static class TestInMemory
    {
        public static UsersData TestUser = new UsersData()
        {
            Id = 1,
            EmailUser = "vladimirbaleev@yandex.ru",
            PasswordUser = "D7tr!qtre98",
            SmtpAddres = "smtp.yandex.ru",
            SmtpPort = 25
        };

        public static List<string> TestAddresMail() => new List<string>
        {
            "ld42ql@gmail.com",
            "ld42ql@icloud.com",
            "ld42ql@hotmail.com"
        };

        public static TextMail TestTextMail = new TextMail()
        {
            Subject = "Тестовое сообщение",
            Body = "Привет.\nЭто тестовое сообщение, отвечать на него не надо :)"
        };
    }
}
