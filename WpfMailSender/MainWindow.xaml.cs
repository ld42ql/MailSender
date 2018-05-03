﻿using System;
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
using WpfMailSender.Test;
using WpfMailSender.WPFWindow;

namespace WpfMailSender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       private EmailSendServiceClass emailSend = new EmailSendServiceClass();

        public MainWindow()
        {
            InitializeComponent();

            ApplyBtn.Click +=
                delegate
                {
                    emailSend.SendMessadge(TestInMemory.TestUser, TestInMemory.TestAddresMail(), TestInMemory.TestTextMail);
                    Statistics();
                };

            EditBtn.Click +=
                delegate
                {
                    new EditWindow(TestInMemory.TestUser).ShowDialog();
                };
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SelectUserPanel.DataContext = TestInMemory.TestUser;
            Statistics();
        }

        private void Statistics()
        {
            StatList.DataContext = emailSend.messadgeStatus;
        }

        private void StatisticsLoaded(object sender, RoutedEventArgs e)
        {
            Statistics();
        }
    }
}
