﻿using System;
using System.Windows;

namespace AuctionClient
{
    /// <summary>
    /// Логика взаимодействия для StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        private void EnterByBuyer_BtnClick(object sender, RoutedEventArgs e)
        {
            stpBuyerInfo.Visibility = Visibility.Visible;
            stpEnter.IsEnabled = false;
        }

        private void EnterBySeller_BtnClick(object sender, RoutedEventArgs e)
        {
            stpSellerInfo.Visibility = Visibility.Visible;
            stpEnter.IsEnabled = false;
        }

        private void Enter_BtnClick(object sender, RoutedEventArgs e)
        {
            int buyerCash = Int32.Parse(tbBuyerCash.Text);
            MainWindow window = new MainWindow(tbBuyerName.Text,buyerCash);
            window.Owner = this; //головне вікно - це.
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.Show();
        }

        private void btnForSeller_Click(object sender, RoutedEventArgs e)
        {
            int sellerCash = Int32.Parse(tbSellerCash.Text);
            SellerWindow sellerWindow = new SellerWindow(tbSellerName.Text, sellerCash);
            sellerWindow.Owner = this;
            sellerWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            sellerWindow.Show();
        }
    }
}
