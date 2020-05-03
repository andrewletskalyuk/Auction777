using System;
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
            //sdfgsdfg
        }

        private void Enter_BtnClick(object sender, RoutedEventArgs e)
        {
            int value = Int32.Parse(tbBuyerCash.Text);
            MainWindow window = new MainWindow(tbBuyerName.Text,value);
            window.Owner = this; //головне вікно - це.
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //window.ShowDialog();
            window.Show();
            //window.PR = this;
        }
    }
}
