using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMailSender.Implementation.Interface;
using WpfMailSender.Implementation.SQL;

namespace WpfMailSender.Services
{
    class DataAccessService : IDataAccessService
    {
        private EmailsDataContext context;

        public DataAccessService()
        {
            this.context = new EmailsDataContext();
        }

        public ObservableCollection<Email> GetEmails()
        {
            ObservableCollection<Email> Emails = new ObservableCollection<Email>();

            foreach (var item in context.Emails)
            {
                Emails.Add(item);
            }
            return Emails;
        }
    }
}
