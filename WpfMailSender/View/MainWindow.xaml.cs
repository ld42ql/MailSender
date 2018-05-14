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
using WpfMailSender.ViewModel;

namespace WpfMailSender.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ViewModelLocator locator;

        public MainWindow()
        {
            InitializeComponent();

            cbSenderSelect.ItemsSource = VariablesClass.Senders;
            cbSenderSelect.DisplayMemberPath = "Key";
            cbSenderSelect.SelectedValuePath = "Value";
            cbSenderSelect.SelectedIndex = 0;

            //cbSmtpSelect.ItemsSource = VariablesClass.SmtpServers;
            //cbSmtpSelect.DisplayMemberPath = "Key";
            //cbSmtpSelect.SelectedValuePath = "Value";
            //cbSmtpSelect.SelectedIndex = 0;

            locator = (ViewModelLocator)FindResource("Locator");

            #region Действия кнопок
            btnSendAtOnce.Click += delegate
            {
                SendAtOnce();
            };

            btnSend.Click += delegate
            {
                Send();
            };

            btnClock.Click += delegate
            {
                SendEmail();
            };

            winClose.Click +=
                delegate
                {
                    this.Close();
                };
            #endregion
        }

        private void Send()
        {
            var sc = new SchedulerClass();
            var tsSendTime = sc.GetSendTime(tbTimePicker.Text);
            if (tsSendTime == new TimeSpan())
            {
                MessageBox.Show("Некорректный формат даты");
                return;
            }
            var dtSendDateTime = (cldSchedulDateTimes.SelectedDate ??
                                       DateTime.Today).Add(tsSendTime);
            if (dtSendDateTime < DateTime.Now)
            {
                MessageBox.Show("Дата и время отправки писем не могут быть раньше, чем настоящее время");
                return;
            }
            var emailSender = new EmailSendServiceClass(cbSenderSelect.Text,
                cbSenderSelect.SelectedValue.ToString());

            sc.SendEmails(dtSendDateTime, emailSender, locator.GetMain().Emails);
        }

        private void SendAtOnce()
        {
            var strLogin = cbSenderSelect.Text;
            var strPassword = cbSenderSelect.SelectedValue.ToString();
            if (string.IsNullOrEmpty(strLogin))
            {
                MessageBox.Show("Выберите отправителя");
                return;
            }
            if (string.IsNullOrEmpty(strPassword))
            {
                MessageBox.Show("Укажите пароль отправителя");
                return;
            }
            var emailSender = new EmailSendServiceClass(strLogin, strPassword);

            emailSender.SendMails(locator.GetMain().Emails);
        }

        private void SendEmail()
        {
            tabControl.SelectedItem = tabPlanner;
        }
    }
}