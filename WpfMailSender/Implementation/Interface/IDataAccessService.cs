using System.Collections.ObjectModel;
using WpfMailSender.Implementation.SQL;

namespace WpfMailSender.Implementation.Interface
{
    interface IDataAccessService
    {
        ObservableCollection<Email> GetEmails();

    }
}
