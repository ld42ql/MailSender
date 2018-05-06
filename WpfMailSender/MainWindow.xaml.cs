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
using WpfMailSender.SQL;
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
                    emailSend = new EmailSendServiceClass(boxUserSender.Text, boxUserSender.SelectedValue.ToString());
                    emailSend.SendMails(db.Emails);
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