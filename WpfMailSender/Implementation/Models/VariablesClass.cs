using System.Collections.Generic;
using PasswordDLL;

namespace WpfMailSender.Implementation.Models
{
    public static class VariablesClass
    {
        private static readonly Dictionary<string, string> dicSenders = new Dictionary<string, string>()
       {
            { "vladimirbaleev@yandex.ru", Cryptographer.GetPassword("Fdfl;jre45") }
       };

        /// <summary>
        /// Коллекция с данными пользователя
        /// </summary>
        public static Dictionary<string, string> Senders => dicSenders;
    }
}
