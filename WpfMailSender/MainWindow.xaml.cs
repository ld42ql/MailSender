using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfMailSender.Implementation.Models;
using WpfMailSender.Implementation.SQL;
using WpfMailSender.WPFWindow;

namespace WpfMailSender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EmailSendServiceClass emailSend;
        DBClass db;

        public MainWindow()
        {
            InitializeComponent();

            
            db = new DBClass();

            btnSendderNow.Click +=
                delegate
                {
                    ActionSendMail();
                };

            btnSendNow.Click +=
                delegate
                {
                    ActionSendMail();
                };

            btnSendSchedule.Click +=
                delegate
                {
                    ActionSendMailSheduler();
                };

            btnEditSender.Click +=
                delegate
                {
                    //new EditWindow(TestInMemory.TestUser).ShowDialog();
                };

            winClose.Click +=
                delegate
                {
                    this.Close();
                };
        }

        private void ActionSendMail()
        {
            emailSend = new EmailSendServiceClass(boxUserSender.Text, boxUserSender.SelectedValue.ToString());
            emailSend.SendMails(db.Emails);
        }

        private void ActionSendMailSheduler()
        {
            SchedulerClass sc = new SchedulerClass();
            TimeSpan tsSendTime = sc.GetSendTime(StrTimePicker.Text);
            if (tsSendTime == new TimeSpan())
            {
                MessageBox.Show("Некорректный формат даты");
                return;
            }
            DateTime dtSendDateTime = (StrCalendar.SelectedDate ?? DateTime.Today).Add(tsSendTime);

            if (dtSendDateTime < DateTime.Now)
            {
                MessageBox.Show("Дата и время отправки писем не могут быть раньше, чем настоящее время");
            return;
            }

            ActionSendMail();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            boxUserSender.ItemsSource = VariablesClass.Senders;
            boxAddressees.ItemsSource = db.Emails;
        }

        private void Statistics()
        {
            StatList.DataContext = db.Emails;
        }

        private void StatisticsLoaded(object sender, RoutedEventArgs e)
        {
            Statistics();
        }
    }
}