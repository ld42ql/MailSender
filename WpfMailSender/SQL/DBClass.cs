using System.Linq;
using WpfMailSender.SQL;

namespace WpfMailSender
{
    /// <summary>
    /// Работа с базой данных
    /// </summary>
   public class DBClass
    {
        private EmailsDataContext emails = new EmailsDataContext();

        /// <summary>
        /// Выдаем почту из базы данных
        /// </summary>
        public IQueryable<Email> Emails { get => from e in this.emails.Emails select e; }
    }
}
