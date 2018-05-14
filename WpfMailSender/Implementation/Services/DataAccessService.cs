using System.Collections.ObjectModel;
using WpfMailSender.Implementation.Interface;
using WpfMailSender.Implementation.SQL;

namespace WpfMailSender.Services
{
    class DataAccessService : IDataAccessService
    {
        private readonly EmailsDataContext context;

        public DataAccessService()
        {
            this.context = new EmailsDataContext();
        }

        public ObservableCollection<Email> GetEmails()
        {
            var emails = new ObservableCollection<Email>();
            foreach (var item in this.context.Emails)
            {
                emails.Add(item);
            }

            return emails;
        }

        public int CreateEmail(Email email)
        {
            this.context.Emails.InsertOnSubmit(email);
            this.context.SubmitChanges();
            return email.Id;
        }
    }
}
