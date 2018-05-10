using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Threading;
using WpfMailSender.Implementation.SQL;

namespace WpfMailSender
{
    /// <summary>
    /// Планировщик
    /// </summary>
    class SchedulerClass
    {
        private readonly DispatcherTimer timer = new DispatcherTimer(); // таймер
        private EmailSendServiceClass emailSender; // экземпляр класса отвечающего за отправку писем
        private DateTime dtSend; // дата и время отправки
        private ObservableCollection<Email> emails; // коллекция email'ов адресатов
                                                     /// <summary>
                                                     /// Методе который превращаем строку из текстбокса tbTimePicker в TimeSpan
                                                     /// </summary>
                                                     /// <param name="strSendTime"></param>
                                                     /// <returns></returns>
        public TimeSpan GetSendTime(string strSendTime)
        {
            TimeSpan tsSendTime = new TimeSpan();
            try
            {
                tsSendTime = TimeSpan.Parse(strSendTime);
            }
            catch
            {
                // ignored
            }

            return tsSendTime;
        }
        /// <summary>
        ////Непостредственно отправка писем
        /// </summary>
        /// <param name="dtSend"></param>
        /// <param name="emailSender"></param>
        /// <param name="emails"></param>
        public void SendEmails(DateTime dtSend, EmailSendServiceClass emailSender,
            ObservableCollection<Email> emails)
        {
            this.emailSender = emailSender; // Экземпляр класса отвечающего за отправку писем присваиваем
            this.dtSend = dtSend;
            this.emails = emails;
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (dtSend.ToShortTimeString() == DateTime.Now.ToShortTimeString())
            {
                emailSender.SendMails(emails);
                timer.Stop();
                MessageBox.Show("Письма отправлены.");
            }
        }

    }

}

