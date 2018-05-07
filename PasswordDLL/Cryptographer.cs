using System;
using System.Security.Cryptography;
using System.Text;

namespace PasswordDLL
{
    public static class Cryptographer
    {
        /// <summary>
        /// Зашифровать 
        /// </summary>
        /// <param name="str">Пароль</param>
        /// <returns>Код</returns>
        public static string GetPassword(string str)
        {
            string password = String.Empty;

            foreach (var item in str)
            {
                var ch = item;
                ch--;
                password += ch;
            }
            return password;
        }

        /// <summary>
        /// Расшифровать
        /// </summary>
        /// <param name="str">Код</param>
        /// <returns>Пароль</returns>
        public static string GetCodPassword(string str)
        {
            string code = String.Empty;

            foreach (var item in str)
            {
                var ch = item;
                ch++;
                code += ch;
            }
            return code;
        }

    }
}

