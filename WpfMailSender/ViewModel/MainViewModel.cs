using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using WpfMailSender.Implementation.Interface;
using WpfMailSender.Implementation.SQL;
using WpfMailSender.Services;

namespace WpfMailSender.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase 
    {

        private ObservableCollection<Email> emails;
        private IDataAccessService serviceProxy;
        private Email emailInfo;
        private string name;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            this.serviceProxy = new DataAccessService();
            this.Emails = new ObservableCollection<Email>();
            this.EmailInfo = new Email();
            this.ReadAllCommand = new RelayCommand(GetEmails);
            this.SaveCommand = new RelayCommand<Email>(SaveEmail);
        }

        public RelayCommand ReadAllCommand { get; set; }
        public RelayCommand<Email> SaveCommand { get; set; }
        public string Name
        {
            set
            {
                this.name = value;
                RaisePropertyChanged(nameof(Name));

            }
        }

        public ObservableCollection<Email> Emails
        {
            get { return this.emails; }
            set
            {
                this.emails = value;
                RaisePropertyChanged(nameof(Emails));
            }
        }

        public Email EmailInfo
        {
            get { return this.emailInfo; }
            set
            {
                this.emailInfo = value;
                RaisePropertyChanged(nameof(EmailInfo));
            }
        }


        private void GetEmails()
        {
            Emails.Clear();
            if (this.name != null && this.name != "")
            {
                foreach (var item in this.serviceProxy.GetEmails())
                {
                    if (item.Name == this.name)
                    {
                        Emails.Add(item);
                    }
                }
            }
            else
            {
                foreach (var item in this.serviceProxy.GetEmails())
                {
                        Emails.Add(item);
                }
            }
        }

        private void SaveEmail(Email email)
        {
            EmailInfo.Id = this.serviceProxy.CreateEmail(email);
            if (EmailInfo.Id != 0)
            {
                Emails.Add(EmailInfo);
                RaisePropertyChanged(nameof(EmailInfo));
            }
        }
    }
}