using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.Windows;
using AuctionClient.ServiceReference1;
using AuctionClient.ViewModel;
using AuctionClient.ViewModel;

namespace AuctionClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window, IAukzionContractCallback
    {
        public AukzionContractClient client;
        //public StartWindow PR { get; set; }
        public AuctionClient.AuctionViewModel viewmodel { get; set; }
        string buyerName;
        int buyerMoney;
        public MainWindow()
        {
            viewmodel = new AuctionViewModel();
            InitializeComponent();
            buyerMoney = 0;
            buyerName = "None";
            this.DataContext = viewmodel;
            lstAuction.ItemsSource = viewmodel.MyLot;
        }
        public MainWindow(string name, int money)
        {
            viewmodel = new AuctionViewModel();
            InitializeComponent();
            buyerMoney = money;
            buyerName = name;

            client = new AukzionContractClient(new InstanceContext(this));

            var connection = client.ConnectionForBuyer(buyerName, buyerMoney);

            var obj = client.GetAllProduct();
            //Створює усі колекції масивами
            foreach (ServerLotDTO item in obj)
            {
                viewmodel.MyLot.Add(item);
            }
            this.DataContext = viewmodel;
            lstAuction.ItemsSource = viewmodel.MyLot;
        }

        public void Bet()
        {
            throw new NotImplementedException();
        }
               
        private void MakeBet_BtnClick(object sender, RoutedEventArgs e)
        {
            ServerLotDTO makeBetLot = (lstAuction.SelectedItem as ServerLotDTO);
            for (int i = 0; i < viewmodel.MyLot.Count; i++)
            {
                if (makeBetLot == viewmodel.MyLot[i])
                {
                    viewmodel.MyLot[i].BuyerName = buyerName;
                    //  buyerMoney -= viewmodel.MyLot[i].SoldPrice;
                }
            }
            //Передача ціни та Ід
            if (makeBetLot != null)
            {
                client.MakeBet(buyerName, makeBetLot.Id, 1000000);
            }

        }

        private void Windows_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            client.DisconnectBayer(buyerName);
        }

        public void UpdateLotsForBuyer(ServerLotDTO[] lots)
        {
            ObservableCollection<ServerLotDTO> update = new ObservableCollection<ServerLotDTO>();
            foreach (ServerLotDTO item in lots)
            {
                update.Add(item);
            }
            viewmodel.MyLot = update;
            lstAuction.ItemsSource = update;
            this.DataContext = viewmodel;
        }
    }
}
