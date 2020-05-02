using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

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

        }

        private void Enter_BtnClick(object sender, RoutedEventArgs e)
        {
            int value = Int32.Parse(tbBuyerCash.Text);
            MainWindow window = new MainWindow(tbBuyerName.Text,value);
            window.ShowDialog();
            window.PR = this;
        }
    }
}
